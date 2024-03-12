using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TweenValidationCheck : MonoBehaviour
{
    [SerializeField] Image borderImage;
    [SerializeField] float durationTime = 2f;
    public bool IsProsessing { get; private set; }

    public Ease EaseType = Ease.Linear;

    private void Start()
    {
        borderImage.color = new Color(borderImage.color.r, borderImage.color.g, borderImage.color.b, 0.0f);
        IsProsessing = false;
    }

    public void Active()
    {
        if (IsProsessing == false)
        {
            IsProsessing = true;
            borderImage.color = new Color(borderImage.color.r, borderImage.color.g, borderImage.color.b, 1.0f);
            borderImage.DOFade(0, durationTime).SetEase(EaseType).OnComplete(() => { IsProsessing = false; });
        }
    }
}