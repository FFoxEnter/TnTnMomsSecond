using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShoppingCart : MonoBehaviour
{
    /// <summary>
    /// 0: Default, 1: Hover.
    /// </summary>
    int UISTATE = 0;
    public enum STATE
    {
        Default,
        Hover,
    }

    string DefaultTag = "Default";
    string HoverTag = "Hover";


    public GameObject Default;
    public GameObject Hover;
    public GameObject DefaultCircle;
    public GameObject HoverCircle;

    public int NumOfProduct;
    public TextMeshProUGUI NumOfProductText;


    private void Awake()
    {
        SetButton();
    }

    private void SetButton()
    {
        Default = FindChildWithTag(this.gameObject, DefaultTag);
        Hover = FindChildWithTag(this.gameObject, HoverTag);
    }

    public void SetNum()
    {
        NumOfProduct = 99;

        NumOfProductText.text = NumOfProduct.ToString();
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

    public void ActivateDefaultCircle()
    {
        Activate(Default, HoverCircle, Hover, DefaultCircle);
    }

    public void ActivateHoverCircle()
    {
        Activate(Hover, DefaultCircle, Default, HoverCircle);
    }

    private void Activate(GameObject activate1, GameObject activate2, GameObject inactivate1, GameObject inactivate2)
    {
        activate1.gameObject.SetActive(true);
        activate2.gameObject.SetActive(true);
        inactivate1.gameObject.SetActive(false);
        inactivate2.gameObject.SetActive(false);
    }

}