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

    private void Start()
    {
        wTime = new WaitForSeconds(fadeDuration + delayTime);
        StartCoroutine(DissolveCo());
    }

    IEnumerator DissolveCo()
    {
        toggles[curIndex].isOn = true;
        yield return new WaitForSeconds(delayTime);

        while (gameObject.activeSelf)
        {            
            dissolves[(curIndex + 2) % dissolves.Length].gameObject.SetActive(false);
            dissolves[(curIndex + 1) % dissolves.Length].gameObject.SetActive(true);
            dissolves[curIndex].StartFadeOut();
            dissolves[(curIndex + 1) % dissolves.Length].StartFadeIn();
            toggles[(curIndex + 1) % dissolves.Length].isOn = true;

            yield return wTime;

            curIndex++;
            if (curIndex >= dissolves.Length)
                curIndex = 0;
            
        }        
    }
}
