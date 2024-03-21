using DA_Assets.Shared.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
    public int tempClickCount = 0;

    private void Awake()
    {
        InitSetting();
    }

    private void Start()
    {
        StartCoroutine(ShowUICo());
    }

    IEnumerator ShowUICo()
    {
        anim.Play(animArray[0]);
        anim.wrapMode = WrapMode.Once;

        yield return new WaitForSeconds(0.75f);

        anim.Play(animArray[1]);
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

    void BellyZone2FMoveButtonClick()
    {
        // 흠냥.
        // 비디오 재생
    }

    public Texture2D ScreenTexture;
    IEnumerator CaptureScreen()
    {
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        yield return new WaitForEndOfFrame();
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
        texture.Apply();
        ScreenTexture = texture;
    }

    public void LoadScreenTexture()
    {
        StartCoroutine(CaptureScreen());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            LoadScreenTexture();
    }
}
