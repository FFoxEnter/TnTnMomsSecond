using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ChangeImageColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button TargetButton;    
    //public UnityEvent _clickAction;    
    public Ease EaseType;
    public float DurationTime = 0.2f;
    [Space(10)]

    [Header("이미지 첫번째")]
    public Image TargetImage;
    public Color NormalColor;
    public Color HoverColor;

    [Header("이미지 두번째")]
    public Image TargetImage2;
    public Color NormalColor2;
    public Color HoverColor2;

    private void Start()
    {
        EventSetting();
    }

    private void OnEnable()
    {
        Normal();
    }

    private void EventSetting()
    {
        if(TargetImage != null)
        {
            TargetImage.color = NormalColor;
            EaseType = Ease.Linear;

            if (TargetImage2 != null)
            {
                TargetImage2.color = NormalColor2;
            }

            //TargetButton.onClick.AddListener(() => _clickAction?.Invoke());
        }
        else
        {
            Debug.LogError("Select Target Image!");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hover();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Normal();
    }

    public void Normal()
    {
        TargetImage.DOColor(NormalColor, DurationTime).SetEase(EaseType);        
        if (TargetImage2 != null)
            TargetImage2.DOColor(NormalColor2, DurationTime).SetEase(EaseType);
    }

    public void Hover()
    {
        TargetImage.DOColor(HoverColor, DurationTime).SetEase(EaseType);
        if (TargetImage2 != null)
            TargetImage2.DOColor(HoverColor2, DurationTime).SetEase(EaseType);
    }

}