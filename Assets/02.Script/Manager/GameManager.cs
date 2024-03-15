using UnityEngine;
using Newtonsoft.Json;

public class GameManager : Singleton<GameManager>
{
    private UIManager uiManager;
    private bool isLoginCompleted = false;

    protected override void Awake()
    {
        base.Awake();
        GetManager();
        CallAwake();
    }

    protected virtual void Start()
    {
        CallStart();
    }

    protected virtual void Update()
    {
        CallUpdate();
    }

    protected virtual void FixedUpdate()
    {
        //CallFixedUpdate();
    }

    protected virtual void LateUpdate()
    {
        //CallLateUpdate();
    }

    private void GetManager()
    {
        uiManager = FindObjectOfType<UIManager>();

    }

    private void CallAwake()
    {
        uiManager.InnerAwake();

        SetFullScreen();
    }

    private void CallStart()
    {
        uiManager.InnerStart();

    }

    private void CallUpdate()
    {
        uiManager.InnerUpdate();

        //AppQuit.instance.ApplicationDoubleTouchQuit();
    }

    private void CallFixedUpdate()
    {

    }

    private void CallLateUpdate()
    {

    }

    private void SetFullScreen()
    {
        Screen.fullScreen = false;
    }

}