using UnityEngine;
using Newtonsoft.Json;

public class GameManager : Singleton<GameManager>
{
    private LoginManager loginScript;
    private UIManager uiManager;
    private bool isLoginCompleted = false;

    protected override void Awake()
    {
        base.Awake();
        GetManager();
        CallAwake();
        loginScript.OnLoginSuccess += HandleLoginSuccess;
    }

    protected virtual void Start()
    {
        if (isLoginCompleted)
        {
            CallStart();
        }
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
        loginScript = FindObjectOfType<LoginManager>();
        uiManager = FindObjectOfType<UIManager>();

    }

    private void CallAwake()
    {
        SetFullScreen();
        loginScript.InnerAwake();
    }

    private void HandleLoginSuccess()
    {
        // 로그인 성공 시 다른 API 스크립트의 InnerAwake() 호출.
        uiManager.InnerAwake();

        // 로그인 완료 플래그.
        isLoginCompleted = true;

        Start();
    }

    private void CallStart()
    {
        uiManager.InnerStart();

    }

    private void CallUpdate()
    {
        uiManager.InnerUpdate();

        AppQuit.instance.ApplicationDoubleTouchQuit();
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