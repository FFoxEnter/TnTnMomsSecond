using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.Events;

public class ToggleHandler : MonoBehaviour
{
    public Toggle toggle;

    [CanBeNull]
    public TextMeshProUGUI[] TMPro;
    public Image[] image;

    // 각각의 이벤트 정의
    public UnityEvent MapOnEvent;
    public UnityEvent MapOffEvent;
    public UnityEvent OtherEvent;

    public static event System.Action<bool> ToggleStateChanged;

    /// <summary>
    /// 가변
    /// </summary>
    private int NumOfText = 2;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();

        for (int i = 0; i < NumOfText; i++)
        {
            if (TMPro.Length == 0)
            {
                TMPro = new TextMeshProUGUI[NumOfText];
            }
        }
    }

    void Start()
    {
        // 토글의 상태 변경 이벤트에 메서드 추가
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            // 여기에 토글이 켜졌을 때 실행할 동작 추가
            if (TMPro[0] != null && TMPro[1] != null)
            {
                ChangeToggleText(TMPro[0], TMPro[1], true, false);
            }

            if (image[0] != null && image[1] != null)
            {
                ChangeToggleImage(image[0], image[1], true, false);
            }

            // MapOnEvent 호출
            if (MapOnEvent != null)
            {
                MapOnEvent.Invoke();
            }
        }
        else
        {
            // 여기에 토글이 꺼졌을 때 실행할 동작 추가
            if (TMPro[0] != null && TMPro[1] != null)
            {
                ChangeToggleText(TMPro[0], TMPro[1], false, true);
            }

            if (image[0] != null && image[1] != null)
            {
                ChangeToggleImage(image[0], image[1], false, true);
            }

            // MapOffEvent 호출
            if (MapOffEvent != null)
            {
                MapOffEvent.Invoke();
            }
        }

        // 정적 이벤트 호출
        ToggleStateChanged?.Invoke(isOn);
    }

    private void ChangeToggleImage(Image image1, Image image2, bool image1flag, bool image2flag)
    {
        if (image1 != null && image2 != null)
        {
            image1.enabled = image1flag;
            image2.enabled = image2flag;
        }
    }

    private void ChangeToggleText(TextMeshProUGUI text1, TextMeshProUGUI text2, bool text1flag, bool text2flag)
    {
        if (text1 != null && text2 != null)
        {
            text1.enabled = text1flag;
            text2.enabled = text2flag;
        }
    }
}
