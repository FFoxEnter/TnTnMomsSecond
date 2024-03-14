using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicCtrl : MonoBehaviour
{
    public GameObject SoundMuted;
    public GameObject SoundFilled;

    public void onClick()
    {
        if (GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Pause();
            SoundFilled.gameObject.SetActive(false);
            SoundMuted.gameObject.SetActive(true);
        }
        else
        {
            GetComponent<AudioSource>().Play();
            SoundMuted.gameObject.SetActive(false);
            SoundFilled.gameObject.SetActive(true);
        }
    }
}
