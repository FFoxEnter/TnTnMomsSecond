using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : Singleton<NavigationManager>
{
    public static NavigationManager Instance;

    private List<NavigationButton> navigationButtons = new List<NavigationButton>();

    private void Awake()
    {
        Instance = this;
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
