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
    [SerializeField] ProductDetail productDetail;

    public string ProductExplainTextString;

    private void Awake()
    {
        ProductExplainText.text = ProductExplainTextString;
        ProductExplain.SetActive(false);
        Binding();
        ProductButton.onClick.AddListener(ProductButtonClick);
    }

    void Binding()
    {
        Transform grandParentTr = transform.parent.parent.transform;
        Transform parentTr = grandParentTr.GetChild(1);
        string[] buttonStrings = gameObject.name.Split(" ");
        foreach (Transform tr in parentTr)
        {
            string[] detailStrings = tr.name.Split(" ");
            if (buttonStrings[1].Equals(detailStrings[1]))
            {
                productDetail = tr.GetComponent<ProductDetail>();
            }
        }
    }

    void ProductButtonClick()
    {
        productDetail.gameObject.SetActive(true);
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
