using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NavigationManager : Singleton<NavigationManager>
{
    public static NavigationManager Instance;

    [SerializeField] Transform parentTransform;

    [SerializeField] List<NavigationButton> navigationButtons = new List<NavigationButton>();
    public SerializedDictionary<string, GameObject> zoneDic = new SerializedDictionary<string, GameObject>();

    public void InnerAwake()
    {
        Instance = this;
    }

    public void AddButton(NavigationButton button)
    {
        navigationButtons.Add(button);

        if (parentTransform == null)
            parentTransform = GameObject.Find("UIZone").transform;

        foreach (Transform tr in parentTransform)
        {
            if (tr.gameObject.name.Contains(button.zone.ToString()))
                zoneDic.Add(button.name, tr.gameObject);
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

    public void InActivateZone()
    {
        foreach (Transform tr in parentTransform)
        {
            if (tr.gameObject.activeSelf == true)
                tr.gameObject.SetActive(false);
        }
    }

    public void ActiviateZoneObj(NavigationButton navButton)
    {
        GameObject panel = null;
        if (zoneDic.TryGetValue(navButton.name.ToString(), out panel) == true)
        {
            panel.SetActive(true);
        }
    }

}