using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    public MovingLineManager MovingLineManager;
    public NavigationManager NavigationManager;

    public void InnerAwake()
    {
        /// OO 루트(예시).
        /// abcdRoot = FindObjectOfType<abcdRoot>();
        /// abcdRoot.InnerAwake();

        MovingLineManager = FindObjectOfType<MovingLineManager>();
        MovingLineManager.InnerAwake();
        NavigationManager = FindObjectOfType<NavigationManager>();
        NavigationManager.InnerAwake();
    }

    public void InnerStart()
    {
        /// abcdRoot.InnerStart();

    }

    public void InnerUpdate()
    {
        /// abcdRoot.InnerUpdate();

    }

    private void HandleABCDSuccess()
    {
    
    }
}
