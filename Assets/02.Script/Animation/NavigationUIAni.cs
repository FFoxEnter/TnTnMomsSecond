using UnityEngine;

public class NavigationUIAni : MonoBehaviour
{
    public Animator Animator;
    
    public void InnerAwake()
    {
        SetNavigationAni();
    }

    public void SetNavigationAni()
    {
        Animator = GetComponent<Animator>();
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
    }

    public void PlayDown()
    {
        PlayAnimation(AnimationName.Down.ToString());
    }
}