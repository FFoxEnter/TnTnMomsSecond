using UnityEngine;
using UnityEngine.UI;

public class NavigationUIAni : MonoBehaviour
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
}