using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverFix : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Vector3 hoverScale = new Vector3(1f, 1f, 1f); // 호버 스케일 값
    [SerializeField] private Vector3 originalScale; // 원래 스케일 값
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Vector2 originalSize;


    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
        originalSize = rectTransform.sizeDelta;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        //rectTransform.localScale = hoverScale;
        rectTransform.sizeDelta = originalSize;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        //rectTransform.localScale = originalScale;
        rectTransform.sizeDelta = originalSize;
    }

    

   
}
