using UnityEngine;
using UnityEngine.Audio;
public class ChangeBGM : MonoBehaviour
{
    public AudioSource BGMAudioSource;
    public AudioSource BGMAudioSource2;
    public SoundCtrl soundCtrl;

    private bool sourceChangeFlag;

    public enum BGMLIST
    {
        Main,
    }
    [SerializeField]
    private BGMLIST BGM;

    private enum BOOTHLAYER
    {
        Main = 26,
        Cafe = 28,
        Counseling = 15,
        Exhibition = 12,
        Market = 14,
        Stage = 11,
        VideoStudio = 27,
        SoundGrabBGM = 22,
        SaltMine = 24,
    }
    void Awake()
    {
        StartCoroutine(AudioMixerFader.StartFade(BGMAudioMixer, "BGMVolume", 0.01f, -20));
    }

    void Start()
    {
        sourceChangeFlag = false;

        BGM = BGMLIST.Main;
        BGMAudioSource.clip = soundCtrl.BGMClips[(int)BGMLIST.Main];
        BGMAudioSource2.clip = soundCtrl.BGMClips[(int)BGMLIST.Main];
    }

    public AudioMixer BGMAudioMixer;

    public void ChangeCurrentBGM()
    {
        if(sourceChangeFlag == false)
        {
            sourceChangeFlag = true;

            StartCoroutine(AudioMixerFader.StartFade(BGMAudioMixer, "BGMVolume", 2.0f, -20));

            switch (BGM)
            {
                case BGMLIST.Main:
                    BGMAudioSource2.clip = soundCtrl.BGMClips[(int)BGMLIST.Main];
                    break;
            }
            BGMAudioSource2.Play();

            StartCoroutine(AudioMixerFader.StartFade(BGMAudioMixer, "BGM2Volume", 2.0f, 20));
        }
        else
        {
            sourceChangeFlag = false;

            StartCoroutine(AudioMixerFader.StartFade(BGMAudioMixer, "BGM2Volume", 2.0f, -20));

            switch (BGM)
            {
                case BGMLIST.Main:
                    BGMAudioSource.clip = soundCtrl.BGMClips[(int)BGMLIST.Main];
                    break;
            }
            BGMAudioSource.Play();

            StartCoroutine(AudioMixerFader.StartFade(BGMAudioMixer, "BGMVolume", 2, 20));
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    switch (other.gameObject.layer)
    //    {
    //        case (int)BOOTHLAYER.Main:
    //            BGM = BGMLIST.Main;
    //            ChangeCurrentBGM();
    //            break;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    BGM = BGMLIST.Main;

    //    switch (other.gameObject.layer)
    //    {
    //        case (int)BOOTHLAYER.Main:
    //            ChangeCurrentBGM();
    //            break;
    //    }
    //}
}