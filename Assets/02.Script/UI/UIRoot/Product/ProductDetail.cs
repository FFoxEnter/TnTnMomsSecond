using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ProductDetail : MonoBehaviour
{
    [Header("-----Panel-----")]
    public GameObject OverseaDeliveryPanel;
    public GameObject ProductDetailImageSection;

    [Header("-----UI-----")]
    public Button ProductDetailButton;
    public Button MoveZoneButton;
    public Button ProductAddButton;
    public Button OverseaDeliveryButton;
    public Button OverseaDeliveryCloseButton;
    public Button ProductDetailCloseButton;

    [Header("-----3DRenderObject-----")]
    public GameObject RenderObject;

    [Header("-----HoverChange-----")]    
    public TextMeshProUGUI ProductAddText;
    public Image ProductAddImage;
    public Sprite AddProductNormalSprite;
    public Sprite AddProductHoverSprite;
    public Sprite AddedProductNormalSprite;
    public Sprite AddedProductHoverSprite;
    ChangeImageColor productAddChangeImageColor;
    ChangeTextColor productAddChangeTextColor;

    public int tempClickCount = 0;

    private void Awake()
    {
        ButtonSetting();
    }

    void ButtonSetting()
    {
        ProductDetailButton.onClick.AddListener(ProductDetailButtonClick);
        //MoveZoneButton.onClick.AddListener();
        ProductAddButton.onClick.AddListener(ProductAddButtonClick);
        productAddChangeImageColor = ProductAddButton.GetComponent<ChangeImageColor>();
        productAddChangeTextColor = ProductAddButton.GetComponent<ChangeTextColor>();
        OverseaDeliveryButton.onClick.AddListener(OverseaDeliveryButtonClick);
        OverseaDeliveryCloseButton.onClick.AddListener(OverseaDeliveryCloseButtonClick);
        ProductDetailCloseButton.onClick.AddListener(ProductDetailCloseButtonClick);
    }

    void ProductDetailButtonClick()
    {
        Application.OpenURL("https://tntnmoms.com/index.html");
    }

    // 흠냥 : 임시
    void ProductAddButtonClick()
    {
        tempClickCount++;

        if (tempClickCount % 2 == 0)
        {
            ProductAddImage.sprite = AddProductNormalSprite;
            SpriteState spriteState = ProductAddButton.spriteState;
            spriteState.highlightedSprite = AddProductHoverSprite;
            ProductAddButton.spriteState = spriteState;
            ProductAddText.text = "add to sample";
        }
        else
        {
            ProductAddImage.sprite = AddedProductNormalSprite;
            SpriteState spriteState = ProductAddButton.spriteState;
            spriteState.highlightedSprite = AddedProductHoverSprite;
            ProductAddButton.spriteState = spriteState;
            ProductAddText.text = "added to sample";
        }
        ChangeImageColorSwap();
        ChangeTextColorSwap();
    }

    void ChangeImageColorSwap()
    {
        var tempColor = productAddChangeImageColor.NormalColor;
        productAddChangeImageColor.NormalColor = productAddChangeImageColor.HoverColor;
        productAddChangeImageColor.HoverColor = tempColor;
    }

    void ChangeTextColorSwap()
    {
        var tempColor = productAddChangeTextColor.NormalColor;
        productAddChangeTextColor.NormalColor = productAddChangeTextColor.HoverColor;
        productAddChangeTextColor.HoverColor = tempColor;
    }

    void OverseaDeliveryButtonClick()
    {
        OverseaDeliveryPanel.SetActive(true);
        ProductDetailImageSection.SetActive(false);
    }

    void OverseaDeliveryCloseButtonClick()
    {
        OverseaDeliveryPanel.SetActive(false);
        ProductDetailImageSection.SetActive(true);
    }

    void ProductDetailCloseButtonClick()
    {
        gameObject.SetActive(false);
    }
}
