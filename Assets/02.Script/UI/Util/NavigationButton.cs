using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationButton : MonoBehaviour
{
    public enum Zone
    {
        MAIN = 1,
        NEWITEM,
        BELLY,
        BREAST,
        SKINCARE,
        ORALCARE,
        BATH,
        FABRIC,
        FOOD
    }

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

    private NavigationManager navigationManager;

    private void Awake()
    {
        SetButton();
        navigationManager = FindObjectOfType<NavigationManager>();

        if (navigationManager != null)
        {
            navigationManager.AddButton(this);
        }
        else
        {
            Debug.LogError("NavigationManager not found.");
        }
    }

    private void SetButton()
    {
        Default = FindChildWithTag(this.gameObject, DefaultTag);
        Hover = FindChildWithTag(this.gameObject, HoverTag);
        Selected = FindChildWithTag(this.gameObject, SelectedTag);
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
        Debug.Log(this.name + " STATE: " + UISTATE);
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
        Debug.Log(this.name + " STATE: " + UISTATE);
        if (UISTATE != (int)STATE.Selected)
        {
            Activate(Hover, Default, Selected);
            UISTATE = (int)STATE.Hover;
        }
    }

    // Hover To Selected.
    public void ActivateSelectedImageSet()
    {
        Debug.Log(this.name + " STATE: " + UISTATE);
        if (navigationManager != null)
        {
            navigationManager.DeselectAllButtonsExcept(this);
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
}
