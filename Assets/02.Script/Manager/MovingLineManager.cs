using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingLineManager : Singleton<MovingLineManager>
{
    public GameObject TimelineRoot;
    public GameObject[] MovingLine;
    [SerializeField] Transform positionParentTransform;
    [SerializeField] List<Transform> posionTransforms;

    [Header("-----Fade-----")]
    [SerializeField] Image uiZoneBGImage;
    private bool isFading = false; // fade 중 여부
    float fadeDuration = 1f;

    Camera mainCam;

    public void InnerAwake()
    {
        TimelineRoot = GameObject.FindWithTag("TimeLine");

        // TimelineRoot의 자식 GameObject들을 검색하여 MovingLine 배열에 할당.
        int childCount = TimelineRoot.transform.childCount;
        MovingLine = new GameObject[childCount];
        for (int i = 0; i < childCount; i++)
        {
            MovingLine[i] = TimelineRoot.transform.GetChild(i).gameObject;
        }

        positionParentTransform = GameObject.Find("[Position]").transform;
        foreach (Transform tr in positionParentTransform)
        {
            posionTransforms.Add(tr);
        }


        uiZoneBGImage = GameObject.Find("UIZoneBG").GetComponent<Image>();

        SetImageAlpha(0.0f);

        mainCam = Camera.main;
    }

    // MovingLine 배열의 특정 인덱스에 해당하는 요소만 활성화하는 함수.
    public void SetActiveMovingLine(int index)
    {
        for (int i = 0; i < MovingLine.Length; i++)
        {
            MovingLine[i].SetActive(i == index);
        }
    }

    public void SetZonePosition(NavigationButton button)
    {
        StartFadeIn();
        GameObject go = null;
        if (NavigationManager.instance.zoneDic.TryGetValue(button.name, out go))
        {
            foreach (Transform tr in posionTransforms)
            {
                if (go.name.Equals(tr.name))
                {                    
                    mainCam.transform.SetLocalPositionAndRotation(tr.localPosition, tr.localRotation);
                }
                    
            }
        }
        StartFadeOut();
    }

    public void FadeInOut()
    {
        StartCoroutine(FadeInOutCo());
    }    

    IEnumerator FadeInOutCo()
    {
        StartFadeIn();
        yield return new WaitForSeconds(0.5f);
        StartFadeOut();
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
}
