using DA_Assets.Shared.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class BellyZone : MonoBehaviour
{
    [Header("-----Panel-----")]
    public GameObject DetailUIPanel;

    [Header("-----Button-----")]
    public Button DetailsButton;
    public Button ProductAddButton;
    public Button BellyZone2FMoveButton;
    public Button DetailUICloseButton;

    [Header("-----HoverChange-----")]
    public TextMeshProUGUI ProductAddText;
    public Image ProductAddImage;
    public Sprite AddProductNormalSprite;
    public Sprite AddProductHoverSprite;
    public Sprite AddedProductNormalSprite;
    public Sprite AddedProductHoverSprite;
    ChangeImageColor productAddChangeImageColor;
    ChangeTextColor productAddChangeTextColor;

    Animation anim;
    List<string> animArray = new List<string>();

    [Header("-----ETC-----")]
    public int tempClickCount = 0;

    private void Awake()
    {
        InitSetting();
    }

    private void OnEnable()
    {
        anim.Play(animArray[0]);
        anim.wrapMode = WrapMode.Once;
    }

    void InitSetting()
    {
        anim = gameObject.GetComponentInChildren<Animation>();
        DetailsButton.onClick.AddListener(DetailsButtonClick);
        ProductAddButton.onClick.AddListener(ProductAddButtonClick);
        productAddChangeImageColor = ProductAddButton.GetComponent<ChangeImageColor>();
        productAddChangeTextColor = ProductAddButton.GetComponent<ChangeTextColor>();
        BellyZone2FMoveButton.onClick.AddListener(BellyZone2FMoveButtonClick);

        DetailUIPanel.SetActive(false);
        BellyZone2FMoveButton.gameObject.SetActive(false);

        foreach (AnimationState state in anim)
        {
            animArray.Add(state.name);
        }

        Belly2FDicAdd();
    }

    void DetailsButtonClick()
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

    void Belly2FDicAdd()
    {
        Transform sFTransform = GameObject.Find("SpecialFeature").transform;
        foreach (Transform tr in sFTransform)
        {
            if (tr.gameObject.name.Contains("Belly2F"))
            {
                NavigationManager.instance.zoneDic.Add(BellyZone2FMoveButton.name, tr.gameObject);
            }
        }
    }

    void BellyZone2FMoveButtonClick()
    {
        NavigationManager.instance.preZoneName = "Belly_Zone";
        NavigationManager.instance.curZoneName = "Belly2F_Zone";
        NavigationManager.instance.InActivateZoneUI();
        MovingLineManager.instance.BellyZone2FStart();
    }    
}
