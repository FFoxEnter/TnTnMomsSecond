using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NavigationManager : Singleton<NavigationManager>
{
    public static NavigationManager Instance;

    [SerializeField] Transform UIZoneparentTransform;
    public string curZoneName = "Main_Zone";
    public string preZoneName = string.Empty;
    [SerializeField] List<NavigationButton> navigationButtons = new List<NavigationButton>();
    public SerializedDictionary<string, GameObject> zoneDic = new SerializedDictionary<string, GameObject>();

    public void InnerAwake()
    {
        Instance = this;
    }

    public void AddButton(NavigationButton button)
    {
        navigationButtons.Add(button);

        if (UIZoneparentTransform == null)
            UIZoneparentTransform = GameObject.Find("UIZone").transform;

        foreach (Transform tr in UIZoneparentTransform)
        {
            AddZoneDic(tr, button);
        }
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

    void AddZoneDic(Transform tr, NavigationButton button)
    {
        string[] strings = tr.gameObject.name.Split('_');
        if (strings[0].Equals(button.zone.ToString()))
            zoneDic.Add(button.name, tr.gameObject);
    }

    public void InActivateZone()
    {
        foreach (Transform tr in UIZoneparentTransform)
        {
            if (tr.gameObject.activeSelf == true)
                tr.gameObject.SetActive(false);
        }
    }

    public void ActiviateZoneObj(NavigationButton navButton)
    {
        StartCoroutine(UIZoneActivateCo(navButton));
    }

    IEnumerator UIZoneActivateCo(NavigationButton navButton)
    {
        yield return new WaitUntil(() => MovingLineManager.instance.isMoving == false);
        GameObject panel = null;
        if (zoneDic.TryGetValue(navButton.name.ToString(), out panel) == true)
        {
            panel.SetActive(true);
        }
    }
}