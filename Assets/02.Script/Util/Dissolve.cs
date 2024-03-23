using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dissolve : MonoBehaviour
{
    DissolveManager dissolveManager;
    [SerializeField] Image image;    
    [SerializeField] bool isFading = false; // fade 중 여부

    private void Awake()
    {
        dissolveManager = GetComponentInParent<DissolveManager>();
        image = GetComponent<Image>();
    }

    private void OnDisable()
    {
        isFading = false;
    }

    public void StartFadeIn()
    {
        if (!isFading)
        {
            StartCoroutine(FadeImage(true));
        }
    }

    public void StartFadeOut()
    {
        if (!isFading)
        {
            StartCoroutine(FadeImage(false));
        }
    }

    IEnumerator FadeImage(bool fadeIn)
    {
        isFading = true;
        
        float firstAlpha = fadeIn ? 0.0f : 1.0f;
        SetImageAlpha(firstAlpha);
        float targetAlpha = fadeIn ? 1.0f : 0.0f;
        float startAlpha = image.color.a;
        float elapsedTime = 0.0f;

        while (elapsedTime < dissolveManager.fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / dissolveManager.fadeDuration);
            SetImageAlpha(newAlpha);
            yield return null;
        }

        SetImageAlpha(targetAlpha); // 알파 값을 목표 값으로 설정 (확실히)
        isFading = false;
    }

    // 이미지의 알파 값을 설정하는 함수
    void SetImageAlpha(float alpha)
    {
        Color color = image.color;
        color.a = alpha;
        image.color = color;
    }
}
