using UnityEngine;
using TMPro;

public class TMPSizeLimitation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI targetTmp;
    [SerializeField] private RectTransform textRectTransform;

    public float WidthLimit = 0.0f;
    public float HeightLimit = 0.0f;

    private bool isTmpNull;

    private void Awake()
    {
        isTmpNull = targetTmp == null ? true : false;
    }

    private void Update()
    {
        SizeLimitation();
    }

    private void SizeLimitation()
    {
        if (isTmpNull == false)
        {
            if (targetTmp.rectTransform.sizeDelta.x > WidthLimit)
            {
                textRectTransform.sizeDelta = new Vector2(WidthLimit, textRectTransform.sizeDelta.y);
                Debug.Log("WidthChange: " + targetTmp.rectTransform.sizeDelta.x);
            }
            else if (targetTmp.rectTransform.sizeDelta.y > HeightLimit)
            {
                textRectTransform.sizeDelta = new Vector2(textRectTransform.sizeDelta.x, HeightLimit);
            }
        }
    }

}