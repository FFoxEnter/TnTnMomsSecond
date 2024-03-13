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

    public GameObject Default;
    public GameObject Hover;
    public GameObject Selected;


    public void ActivateButtonByState()
    {

    }

    private void Activate(GameObject activate, GameObject inactivate)
    {

    }


    public void Moving()
    {

    }


}