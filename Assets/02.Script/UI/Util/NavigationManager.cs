using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : Singleton<NavigationManager>
{
    public static NavigationManager Instance;

    [SerializeField] Transform parentTransform;

    [SerializeField] List<NavigationButton> navigationButtons = new List<NavigationButton>();
    public List<GameObject> zoneObj = new List<GameObject>();

    public void InnerAwake()
    {
        Instance = this;
    }

    public void InnerStart()
    {
        parentTransform = GameObject.Find("UIZone").transform;
        foreach (Transform tr in parentTransform)
        {
            zoneObj.Add(tr.gameObject);
        }
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
}
