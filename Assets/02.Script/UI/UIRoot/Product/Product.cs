using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Product : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject ProductExplain;
    public TextMeshProUGUI ProductExplainText;
    public Button ProductButton;

    public string ProductExplainTextString;

    private void Start()
    {
        ProductExplainText.text = ProductExplainTextString;
        ProductExplain.SetActive(false);
        NameSetting();
    }

    void NameSetting()
    {
        string[] strings = ProductExplainText.text.Split(' ');
        gameObject.name = $"Product_{strings[0]}";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ProductExplain.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ProductExplain.SetActive(false);
    }
}
