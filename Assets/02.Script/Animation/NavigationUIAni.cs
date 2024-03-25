using UnityEngine;
using UnityEngine.UI;

public class NavigationUIAni : Singleton<NavigationUIAni>
{
    public Animator Animator;
    public Toggle ViewAllToggle;
    public Toggle MapToggle;

    public void InnerAwake()
    {
        SetNavigationAni();
    }

    public void SetNavigationAni()
    {
        Animator = GetComponent<Animator>();

        ViewAllToggle.enabled = false;
        MapToggle.enabled = false;

        ViewAllToggle.gameObject.SetActive(false);
        MapToggle.gameObject.SetActive(false);

        // MapOnToggle의 값이 변경될 때 호출될 메서드를 설정
        MapToggle.onValueChanged.AddListener(OnMapToggleValueChanged);
    }

    public enum AnimationName
    {
        Up,
        Down,
    }
    
    public void PlayAnimation(string AnimationName)
    {
        Animator.SetTrigger(AnimationName);
    }

    public void PlayUp()
    {
        PlayAnimation(AnimationName.Up.ToString());
        ViewAllToggle.enabled = true;
        MapToggle.enabled = true;
    }

    public void PlayDown()
    {
        PlayAnimation(AnimationName.Down.ToString());
    }

    // 외부 Toggle 상태가 변경될 때 호출되는 메서드.
    public void OnMapToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            PlayUp();
        }
        else
        {
            PlayDown();
        }
    }
}