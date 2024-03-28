using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum Zone
{
    Main = 1,
    NewItem,
    Belly,
    Breast,
    SkinCare,
    OralCare,
    Bath,
    Fabric,
    Food,
    Belly2f,
}

public class NavigationButton : MonoBehaviour
{
    public Zone zone;

    /// <summary>
    /// 0: Default, 1: Hover, 2: Selected.
    /// </summary>
    int UISTATE = 0;
    public enum STATE
    {
        Default,
        Hover,
        Selected,
    }


    string DefaultTag = "Default";
    string HoverTag = "Hover";
    string SelectedTag = "Selected";

    public GameObject Default;
    public GameObject Hover;
    public GameObject Selected;

    [SerializeField] NavigationManager naviManager;

    private void Start()
    {
        SetButton();
        SetNavigationManager();
        SetButtonFunction();
        NaviButtonAddDic();
    }

    private void SetButton()
    {
        Default = FindChildWithTag(this.gameObject, DefaultTag);
        Hover = FindChildWithTag(this.gameObject, HoverTag);
        Selected = FindChildWithTag(this.gameObject, SelectedTag);
    }

    void NaviButtonAddDic()
    {
        // 흠냥 : 임시
        Transform specialFeatureParentTr = naviManager.SpecialFeatureParentTransform;
        foreach (Transform uiZoneTr in specialFeatureParentTr)
        {
            string[] strings = uiZoneTr.gameObject.name.Split('_');
            if (strings[0].Equals(zone.ToString()))
            {
                naviManager.UIZoneDic.Add(zone.ToString(), uiZoneTr.gameObject);
                break;
            }
        }
    }
    
    private void SetNavigationManager()
    {
        if (NavigationManager.Instance != null)
        {
            naviManager = NavigationManager.Instance;
            naviManager.AddButton(this);                 
        }
        else
        {
            Debug.Log("NavigationManager not found.");
        }
    }

    private void SetButtonFunction()
    {
        GetComponent<Button>().onClick.AddListener(ButtonFunction);
    }


    private GameObject FindChildWithTag(GameObject parent, string tag)
    {
        GameObject child = null;

        foreach (Transform transform in parent.transform)
        {
            if (transform.CompareTag(tag))
            {
                child = transform.gameObject;
                break;
            }
        }

        return child;
    }

    // Hover To Default.
    public void ActivateDefaultImageSet()
    {
        if (UISTATE != (int)STATE.Selected)
        {
            Activate(Default, Hover, Selected);
            UISTATE = (int)STATE.Default;
        }
    }

    public void SetToDefault()
    {
        UISTATE = (int)STATE.Default;
    }

    // Default to Hover.
    public void ActivateHoverImageSet()
    {
        if (UISTATE != (int)STATE.Selected)
        {
            Activate(Hover, Default, Selected);
            UISTATE = (int)STATE.Hover;
        }
    }

    // Hover To Selected.
    public void ActivateSelectedImageSet()
    {
        if (NavigationManager.Instance != null)
        {
            NavigationManager.instance.DeselectAllButtonsExcept(this);
        }
        Activate(Selected, Default, Hover);
        UISTATE = (int)STATE.Selected;
    }

    public void Deselect()
    {
        SetToDefault();
        ActivateDefaultImageSet();
    }

    private void Activate(GameObject activate, GameObject inactivate1, GameObject inactivate2)
    {
        activate.gameObject.SetActive(true);
        inactivate1.gameObject.SetActive(false);
        inactivate2.gameObject.SetActive(false);
    }           

    private void ButtonFunction()
    {       
        SetCurZone();

        if (naviManager.preZoneName.Equals(naviManager.curZoneName))
            return;

        naviManager.InActivateZoneUI();
        MovingLineManager.instance.MoveZone(this);

        UIZoneActivate();
    }

    void SetCurZone()
    {
        naviManager.preZoneName = naviManager.curZoneName;
        naviManager.curZoneName = $"{zone}_Zone";
    }

    void UIZoneActivate()
    {        
        naviManager.ActiviateZoneObj(this);
    }
}
