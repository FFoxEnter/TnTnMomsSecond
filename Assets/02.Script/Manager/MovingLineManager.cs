using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering;
using UnityEngine.UI;

public enum EMovingLineVideo
{
    V_intro,
    V_Bodypillow,
    V_Blanket,
    V_Bearcusion,
    V_FabricTo1st,
    Egg_EV_left,
    Egg_EV_right,
    V_Newitem,
    V_Bearbelly,
}

public class MovingLineManager : Singleton<MovingLineManager>
{
    public GameObject TimelineRoot;
    public GameObject[] MovingLine;
    public SerializedDictionary<EMovingLineVideo, GameObject> MovingLineVideoDic = new SerializedDictionary<EMovingLineVideo, GameObject>();

    [Header("-----CameraPosition-----")]
    Transform initPositionParentTransform;
    [SerializeField] List<Transform> initPosionTransformList;
    Transform zoomPositionParentTransform;
    [SerializeField] List<Transform> zoomPosionTransformList;

    [Header("-----Fade-----")]
    [SerializeField] Image uiZoneBGImage;
    private bool isFading = false; // fade 중 여부
    float fadeDuration = 1f;
    public bool isMoving = false;

    [Header("-----ETC-----")]
    Camera mainCam;
    public GameObject curPlayingVideo;
    public Coroutine mainCamMoveCo;
    public Coroutine CamZoomCo;

    public void InnerAwake()
    {
        MovingLineSetting();
        InitPositionSetting();
        ZoomPositionSetting();

        if (uiZoneBGImage == null)
            uiZoneBGImage = UIRoot.Instance.FadeInOutBg;

        SetImageAlpha(0.0f);

        mainCam = Camera.main;
    }

    void MovingLineSetting()
    {
        TimelineRoot = GameObject.FindWithTag("TimeLine");

        // TimelineRoot의 자식 GameObject들을 검색하여 MovingLine 배열에 할당.
        int childCount = TimelineRoot.transform.childCount;
        MovingLine = new GameObject[childCount];
        var videoList = Enum.GetValues(typeof(EMovingLineVideo));
        foreach (EMovingLineVideo video in videoList)
        {
            for (int i = 0; i < childCount; i++)
            {
                MovingLine[i] = TimelineRoot.transform.GetChild(i).gameObject;
                if (MovingLine[i].name.Equals(video.ToString()))
                {
                    if (!MovingLineVideoDic.ContainsKey(video))
                        MovingLineVideoDic.Add(video, MovingLine[i]);
                    break;
                }
            }
        }
    }

    void InitPositionSetting()
    {
        initPositionParentTransform = GameObject.Find("[InitPosition]").transform;
        foreach (Transform tr in initPositionParentTransform)
        {
            initPosionTransformList.Add(tr);
        }
    }

    void ZoomPositionSetting()
    {
        zoomPositionParentTransform = GameObject.Find("[ZoomPosition]").transform;
        foreach (Transform tr in zoomPositionParentTransform)
        {
            zoomPosionTransformList.Add(tr);
        }
    }

    public void MoveZone(NavigationButton button)
    {
        SetImageAlpha(0.0f);
        StopAllCamCo();
        isFading = false;
        AllVideoOff();
        mainCamMoveCo = StartCoroutine(SetMainCamPosRotCo(button));
    }

    public void StopAllCamCo()
    {
        if (mainCamMoveCo != null)
        {
            StopCoroutine(mainCamMoveCo);
            mainCamMoveCo = null;
        }
        
        if (CamZoomCo != null)
        {
            StopCoroutine(CamZoomCo);
            CamZoomCo = null;
        }
    }

    IEnumerator SetMainCamPosRotCo(NavigationButton button)
    {
        isMoving = true;
        StartFadeIn();
        yield return new WaitUntil(() => isFading == false);

        GameObject uIZone = null;
        if (NavigationManager.instance.zoneDic.TryGetValue(button.name, out uIZone))
        {
            foreach (Transform tr in initPosionTransformList)
            {
                if (uIZone.name.Equals(tr.name))
                {
                    mainCam.transform.SetLocalPositionAndRotation(tr.localPosition, tr.localRotation);
                }
            }
        }

        NavigationManager.instance.InitViewAllButtonSetting();

        if (button.zone == NavigationButton.Zone.Main)
            NavigationManager.instance.SpecialButtonView(false);
        else
            NavigationManager.instance.SpecialButtonView(true);

        StartFadeOut();
        
        CamZoomCo = StartCoroutine(CameraZoom(button));
    }

    // fade in 효과를 시작하는 함수
    public void StartFadeIn()
    {
        if (!isFading)
        {
            StartCoroutine(FadeImage(true));
        }
    }

    // fade out 효과를 시작하는 함수
    public void StartFadeOut()
    {
        if (!isFading)
        {
            StartCoroutine(FadeImage(false));
        }
    }

    // 이미지의 알파 값을 설정하는 함수
    void SetImageAlpha(float alpha)
    {
        Color color = uiZoneBGImage.color;
        color.a = alpha;
        uiZoneBGImage.color = color;
    }

    // fade in/out 효과를 적용하는 코루틴 함수
    IEnumerator FadeImage(bool fadeIn)
    {
        isFading = true;

        float targetAlpha = fadeIn ? 1.0f : 0.0f;
        float startAlpha = uiZoneBGImage.color.a;
        float elapsedTime = 0.0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            SetImageAlpha(newAlpha);
            yield return null;
        }

        SetImageAlpha(targetAlpha); // 알파 값을 목표 값으로 설정 (확실히)
        isFading = false;
    }

    // 흠냥 : 임시
    public float smoothSpeed = 0.125f; // 부드러운 이동을 위한 속도
    Vector3 desiredPosition;
    Quaternion desiredRotation;
    IEnumerator CameraZoom(NavigationButton button)
    {
        GameObject uIZone = null;
        if (NavigationManager.instance.zoneDic.TryGetValue(button.name, out uIZone))
        {
            foreach (Transform tr in zoomPosionTransformList)
            {
                if (uIZone.name.Equals(tr.name))
                {
                    desiredPosition = tr.localPosition;
                    desiredRotation = tr.localRotation;
                    break;
                }
            }
        }

        Invoke("InvokeStateCall", 2.0f);
   
        while (mainCam.transform.localPosition != desiredPosition || mainCam.transform.localRotation != desiredRotation)
        {
            mainCam.transform.localPosition = Vector3.MoveTowards(mainCam.transform.localPosition, desiredPosition, smoothSpeed * Time.deltaTime); // 카메라의 위치를 부드럽게 이동된 위치로 설정
            mainCam.transform.localRotation = Quaternion.Lerp(mainCam.transform.localRotation, desiredRotation, (smoothSpeed+0.6f) * Time.deltaTime);

            yield return null;
        }

        mainCam.transform.localPosition = desiredPosition;
        mainCam.transform.localRotation = desiredRotation;
        isMoving = false;
        
        MovingLineCheck();
    }    

    public void MovingLineCheck()
    {
        switch (NavigationManager.instance.curZoneName)
        {
            case "NewItem_Zone":
                PlayMovingLine(EMovingLineVideo.V_Newitem);
                break;
            case "Belly_Zone":
                break;
            case "Belly2F_Zone":
                break;
            case "Breast_Zone":
                break;
            case "Breast2_Zone":
                break;
            case "SkinCare_Zone":
                break;
            case "OralCare_Zone":
                break;
            case "Bath_Zone":
                break;
            case "Fabric_Zone":
                break;
            case "Food_Zone":
                break;
        }
    }

    public void PlayMovingLine(EMovingLineVideo eMovingLineVideo)
    {
        GameObject video = null;
        if (MovingLineVideoDic.TryGetValue(eMovingLineVideo, out video) == true)
        {
            curPlayingVideo = video;
            video.SetActive(true);
        }
    }

    public void CameraMove(string curZoneName, bool isZoom)
    {
        StartCoroutine(CameraMoveCo(curZoneName, isZoom));
    }

    IEnumerator CameraMoveCo(string curZoneName, bool isZoom)
    {
        isMoving = true;
        List<Transform> list = new List<Transform>();
        if (isZoom)
        {
            list = zoomPosionTransformList;
            NavigationManager.instance.ActiviateZoneObj(curZoneName);
            
        }
        else
        {
            list = initPosionTransformList;
            NavigationManager.instance.InActivateZoneUI();
        }

        foreach (Transform tr in list)
        {
            if (curZoneName.Equals(tr.gameObject.name))
            {
                desiredPosition = tr.localPosition;
                desiredRotation = tr.localRotation;
            }
        }        

        while (mainCam.transform.localPosition != desiredPosition || mainCam.transform.localRotation != desiredRotation)
        {
            mainCam.transform.localPosition = Vector3.MoveTowards(mainCam.transform.localPosition, desiredPosition, smoothSpeed * Time.deltaTime); // 카메라의 위치를 부드럽게 이동된 위치로 설정
            mainCam.transform.localRotation = Quaternion.Lerp(mainCam.transform.localRotation, desiredRotation, (smoothSpeed + 0.6f) * Time.deltaTime);

            yield return null;
        }
        mainCam.transform.localPosition = desiredPosition;
        mainCam.transform.localRotation = desiredRotation;
        isMoving = false;
    }

    public void AllVideoOff()
    {
        for (int i = 0; i < MovingLine.Length; i++)
        {
            if (MovingLine[i].activeSelf)
                MovingLine[i].SetActive(false);
        }
    }

    public void BellyZone2FStart()
    {
        StartCoroutine(BellyZone2FStartCo());
    }

    IEnumerator BellyZone2FStartCo()
    {
        UIRoot.Instance.curUIZone.SetActive(false);
        PlayMovingLine(EMovingLineVideo.V_Bearbelly);

        GameObject curVideo = curPlayingVideo;
        PlayableDirector playableDirector = curVideo.GetComponent<PlayableDirector>();

        yield return new WaitUntil(() => playableDirector.state == PlayState.Paused);

        GameObject panel = null;
        if (NavigationManager.instance.zoneDic.TryGetValue("btn - 2F Belly Zone", out panel) == true)
        {
            UIRoot.Instance.curUIZone = panel;
            panel.SetActive(true);
        }
    }

    private void InvokeStateCall()
    {
        BellyPatchRoot.instance.ChangeState(BellyPatchRoot.GameState.State2);
    }


}
