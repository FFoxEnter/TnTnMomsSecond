using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIRoot : MonoBehaviour
{
    private static UIRoot instance;

    public static UIRoot Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIRoot>();
            }
            return instance;
        }
    }

    [Header("-----Select-----")]
    public GameObject SelectPanel;
    public Button MobileButton;
    public Button PCButton;

    [Header("-----MobileRotate-----")]
    public GameObject MobileRotatePanel;
    public GameObject[] RotateIconObj;
    Coroutine curCoroutine;

    [Header("-----Video-----")]
    public GameObject IntroVideoPanel;
    public VideoPlayer IntroVideoPlayer;
    public bool isIntroVideoPlay = false;

    [Header("-----Temp-----")]
    public GameObject NewItemZonePanel;

    private void Awake()
    {
        instance = this;
        ButtonClickEvent();
        InitSetting();
    }

    void InitSetting()
    {
        SelectPanel.SetActive(true);
        MobileRotatePanel.SetActive(false);
        IntroVideoPanel.SetActive(false);

        isIntroVideoPlay = false;
    }

    void ButtonClickEvent()
    {
        MobileButton.onClick.AddListener(MobileButtonClick);
        PCButton.onClick.AddListener(PCButtonClick);
    }

    void MobileButtonClick()
    {
        MobileRotatePanel.SetActive(true);
        curCoroutine = StartCoroutine(MobileRotateCo());
        SelectPanel.SetActive(false);
    }

    void PCButtonClick()
    {
        SelectPanel.SetActive(false);
        curCoroutine = StartCoroutine(StartIntroVideo());
    }

    WaitForSeconds w05 = new WaitForSeconds(0.5f);
    IEnumerator MobileRotateCo()
    {
        int i = 0;
        while (MobileRotatePanel.activeSelf)
        {
            if ( i == 0)
                RotateIconObj[RotateIconObj.Length - 1].SetActive(false);
            RotateIconObj[i].SetActive(true);
            yield return w05;
            RotateIconObj[i].SetActive(false);
            if (i < RotateIconObj.Length - 1)
            {
                RotateIconObj[i + 1].SetActive(true);
                i++;
            }
            else
                i = 0;

            if (Screen.width > Screen.height)
            {
                if (!isIntroVideoPlay)
                {
                    //StopCoroutine(curCoroutine);
                    curCoroutine = null;
                    curCoroutine = StartCoroutine(StartIntroVideo());                    
                    yield break;
                }
            }
        }        
    }

    IEnumerator StartIntroVideo()
    {
        isIntroVideoPlay = true;
        string introVideoURL = System.IO.Path.Combine(Application.streamingAssetsPath, "IntroVideo.mp4");
        IntroVideoPlayer.url = introVideoURL;        
        IntroVideoPanel.SetActive(true);
        MobileRotatePanel.SetActive(false);

        yield return new WaitUntil(() => IntroVideoPlayer.isPlaying == false);

        IntroVideoPanel.SetActive(false);
        NewItemZonePanel.SetActive(true);
        curCoroutine = null;
    }    
}