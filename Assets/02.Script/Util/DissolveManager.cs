using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DissolveManager : MonoBehaviour
{
    public int curIndex = 0;
    public Dissolve[] dissolves;
    public Toggle[] toggles;
    public float fadeDuration = 2f;
    [SerializeField] float delayTime = 3f;
    WaitForSeconds wTime;
    Coroutine curDissolveCo;

    private void Awake()
    {
        wTime = new WaitForSeconds(fadeDuration + delayTime);
    }

    private void OnEnable()
    {
        if (curDissolveCo != null)
        {
            StopCoroutine(curDissolveCo);
            curDissolveCo = null;            
        }
        curDissolveCo = StartCoroutine(DissolveCo());
    }   

    void InitSetting()
    {
        curIndex = 0;
        dissolves[0].gameObject.SetActive(true);
    }

    IEnumerator DissolveCo()
    {
        InitSetting();
        toggles[curIndex].isOn = true;
        yield return new WaitForSeconds(delayTime);

        while (gameObject.activeSelf)
        {            
            dissolves[(curIndex + 2) % dissolves.Length].gameObject.SetActive(false);
            dissolves[(curIndex + 1) % dissolves.Length].gameObject.SetActive(true);
            dissolves[curIndex].StartFadeOut();
            dissolves[(curIndex + 1) % dissolves.Length].StartFadeIn();
            toggles[(curIndex + 1) % dissolves.Length].isOn = true;
            curIndex++;
            yield return wTime;

            
            if (curIndex >= dissolves.Length)
                curIndex = 0;
            
        }        
    }
}
