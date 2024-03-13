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

    string DefaultTag = "Default";
    string HoverTag = "Hover";
    string SelectedTag = "Selected";


    public GameObject Default;
    public GameObject Hover;
    public GameObject Selected;

    private void Awake()
    {
        SetButton();
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

    public void ActivateDefaultImageSet()
    {
        Activate(Default, Hover, Selected);
    }

    public void ActivateHoverImageSet()
    {
        Activate(Hover, Default, Selected);
    }

    public void ActivateSelectedImageSet()
    {
        Activate(Selected, Default, Hover);
    }

    private void Activate(GameObject activate, GameObject inactivate1, GameObject inactivate2)
    {
        activate.gameObject.SetActive(true);
        inactivate1.gameObject.SetActive(false);
        inactivate2.gameObject.SetActive(false);
    }


    public void MovingLine()
    {

    }


}