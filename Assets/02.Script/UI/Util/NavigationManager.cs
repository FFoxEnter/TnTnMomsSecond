using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class NavigationManager : Singleton<NavigationManager>
{
    public static NavigationManager Instance;

    public Transform SpecialFeatureParentTransform;
    public string curZoneName = "Main_Zone";
    public string preZoneName = string.Empty;
    [SerializeField] List<NavigationButton> navigationButtons = new List<NavigationButton>();
    public SerializedDictionary<string, GameObject> UIZoneDic = new SerializedDictionary<string, GameObject>();

    public Coroutine zoneUICo;

    [Header("-----NaviMap-----")]
    public GameObject MapOnText;
    public GameObject MapOffText;
    public Image MapOnImage;
    public Image MapOffImage;
    public Button ViewAllButton;
    public Button ViewBackButton;
    public Toggle mapToggle;
    Animator naviMapAnim;       

    public void InnerAwake()
    {
        Instance = this;
        naviMapAnim = GetComponent<Animator>();
        mapToggle.onValueChanged.AddListener(delegate { OnMapStateChanged(mapToggle); }) ;
        ViewAllButton.onClick.AddListener(ViewAllButtonClick);
        ViewBackButton.onClick.AddListener(ViewBackButtonClick);
        ViewBackButton.gameObject.SetActive(false);
        mapToggle.isOn = false;
        SpecialButtonView(false);
        SpecialFeatureParentTransform = GameObject.Find("SpecialFeature").transform;
    }

    public void SpecialButtonView(bool value)
    {
        if (ViewAllButton.gameObject.activeSelf != value || mapToggle.gameObject.activeSelf != value)
        {
            ViewAllButton.gameObject.SetActive(value);
            mapToggle.gameObject.SetActive(value);
        }        
    }

    public void InitViewAllButtonSetting()
    {
        ViewAllButton.gameObject.SetActive(true);
        ViewBackButton.gameObject.SetActive(false);
    }

    public void ShowNaviMap(bool value)
    {
        mapToggle.isOn = value;

        MapOnText.SetActive(value);
        MapOffText.SetActive(!value);

        naviMapAnim.SetBool("isMapOn", value);
    }

    public void AddButton(NavigationButton button)
    {
        navigationButtons.Add(button);
    }

    public void DeselectAllButtonsExcept(NavigationButton selectedButton)
    {
        foreach (NavigationButton button in navigationButtons)
        {
            if (button != selectedButton)
            {
                button.Deselect();
                Debug.Log(button.name + " is Deselected");
            }
        }
    }

    public void InActivateZoneUI()
    {
        foreach (Transform tr in SpecialFeatureParentTransform)
        {
            if (tr.gameObject.activeSelf == true)
                tr.gameObject.SetActive(false);
        }
    }

    public void ActiviateZoneObj(NavigationButton navButton)
    {
        if (zoneUICo != null)
        {
            StopCoroutine(zoneUICo);
            zoneUICo = null;
        }
        zoneUICo = StartCoroutine(UIZoneActivateCo(navButton));
    }    

    IEnumerator UIZoneActivateCo(NavigationButton navButton)
    {
        yield return new WaitUntil(() => MovingLineManager.instance.isMoving == false);

        if (navButton.zone == Zone.SkinCare)
        {
            PlayableDirector playableDirector = MovingLineManager.instance.curPlayingVideo.GetComponent<PlayableDirector>();            
            yield return new WaitUntil(() => playableDirector.time > 6.3d);
        }   

        GameObject panel = null;
        if (UIZoneDic.TryGetValue(navButton.zone.ToString(), out panel) == true)
        {
            UIRoot.Instance.curUIZone = panel;
            panel.SetActive(true);
        }
    }

    public void ActiviateZoneObj(string curZoneName)
    {
        if (zoneUICo != null)
        {
            StopCoroutine(zoneUICo);
            zoneUICo = null;
        }
        zoneUICo = StartCoroutine(UIZoneActivateCo(curZoneName));
    }

    IEnumerator UIZoneActivateCo(string curZoneName)
    {
        yield return new WaitUntil(() => MovingLineManager.instance.isMoving == false);
        foreach (Transform tr in SpecialFeatureParentTransform)
        {
            if (tr.gameObject.name.Equals(curZoneName))
            {
                UIRoot.Instance.curUIZone = tr.gameObject;
                tr.gameObject.SetActive(true);
            }
                
        }

        MovingLineManager.instance.MovingLineCheck();
    }

    void OnMapStateChanged(Toggle toggle)
    {
        MapOnText.SetActive(toggle.isOn);
        MapOffText.SetActive(!toggle.isOn);
        MapOnImage.enabled = toggle.isOn;
        MapOffImage.enabled = !toggle.isOn;

        naviMapAnim.SetBool("isMapOn", toggle.isOn);
    }

    void ViewAllButtonClick()
    {     
        MovingLineManager.instance.StopAllCamCo();
        MovingLineManager.instance.AllVideoOff();
        MovingLineManager.instance.CameraMove(curZoneName, false);
        ViewAllButton.gameObject.SetActive(false);
        ViewBackButton.gameObject.SetActive(true);
    }

    void ViewBackButtonClick()
    {
        MovingLineManager.instance.StopAllCamCo();
        MovingLineManager.instance.AllVideoOff();
        MovingLineManager.instance.CameraMove(curZoneName, true);
        ViewAllButton.gameObject.SetActive(true);
        ViewBackButton.gameObject.SetActive(false);       
    }
}