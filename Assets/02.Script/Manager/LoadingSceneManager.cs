using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingSceneManager : MonoBehaviour
{
    [SerializeField] Slider loadingSlider;
    [SerializeField] TextMeshProUGUI loadingText;

    void Start()
    {
        if (loadingSlider == null)
            loadingSlider = FindObjectOfType<Slider>();
        if (loadingText == null)
        {
            loadingText = GameObject.Find("LoadingText").GetComponent<TextMeshProUGUI>();
        }
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("TnTnMain");

        while (!asyncLoad.isDone)
        {        
            loadingSlider.value = asyncLoad.progress;
            int progress = Mathf.RoundToInt(asyncLoad.progress * 100);
            loadingText.text = $"Loading {progress}%";

            yield return null;
        }
    }
}
