using UnityEngine;
using UnityEngine.Audio;

public class SoundCtrl : MonoBehaviour
{
    public enum Sound
    {
        BGM,
        BGM2,
        SFX,
    }
    public AudioSource[] audioSources;

    [Header("0. Main, 1. , 2. , 3. , 4. , 5. , 6. , 7. , 8. ")]
    public AudioClip[] BGMClips;

    public void Play(AudioClip audioClip, Sound type = Sound.SFX, float pitch = 1.0f)
    {
        if (audioClip == null)
            return;

        if (type == Sound.BGM)
        {
            AudioSource audioSource = audioSources[(int)Sound.BGM];
            if (audioSource.isPlaying)
                audioSource.Stop();

            audioSource.pitch = pitch;
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else if (type == Sound.SFX)
        {
            AudioSource audioSource = audioSources[(int)Sound.SFX];
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip);
        }
        else if (type == Sound.BGM2)
        {
            AudioSource audioSource = audioSources[(int)Sound.BGM2];
            if (audioSource.isPlaying)
                audioSource.Stop();

            audioSource.pitch = pitch;
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }

    public enum UISound
    {
        HOVER,
        CLICK,
    }

    public AudioSource[] audioClips;

    public void PlaySfxHover()
    {
        audioClips[(int)UISound.HOVER].Play();
    }
    public void PlaySfxClick()
    {
        audioClips[(int)UISound.CLICK].Play();
    }

    public AudioMixer BGMAudioMixer;
    public UnityEngine.UI.Toggle SoundToggle;
    public void NoSounds()
    {
        AudioListener.pause = !SoundToggle.isOn;
        if (AudioListener.pause == true)
        {
            StartCoroutine(AudioMixerFader.StartFade(BGMAudioMixer, "BGMVolume", 0.01f, -20));
        }
    }

    public void StartSounds()
    {
        audioSources[0].Play();
        audioSources[2].Play();
        StartCoroutine(AudioMixerFader.StartFade(BGMAudioMixer, "BGMVolume", 2.0f, 20));
    }

}