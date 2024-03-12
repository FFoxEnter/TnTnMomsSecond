using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;
using UnityEngine.Serialization;

public class ChangeTextColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button TargetButton;
    public TextMeshProUGUI TargetText;
    //public Text TargetText;

    [Space(20)]
    public Ease EaseType;
    public float DurationTime = 0.2f;

    public Color NormalColor;
    public Color HoverColor;

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
        if(!string.IsNullOrEmpty(TargetText.text))
        {
            TargetText.color = NormalColor;
            EaseType = Ease.Linear;
        }
        else
        {
            Debug.LogError("Select Target Text!");
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
        TargetText.DOColor(NormalColor, DurationTime).SetEase(EaseType);
    }

    public void Hover()
    {
        TargetText.DOColor(HoverColor, DurationTime).SetEase(EaseType);
    }

}