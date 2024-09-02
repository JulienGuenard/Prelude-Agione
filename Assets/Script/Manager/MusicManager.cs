using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public AudioSource sfxAudio;
    public List<AudioSource> musicAudioList;
    public AudioMixer mixer;
    public AudioMixerSnapshot snapFadeIn;
    public AudioMixerSnapshot snapFadeOut;

    #region instance
    public static MusicManager instance;

    void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Start()
    {
        snapFadeOut.TransitionTo(0.01f);
    }

    public void sfxVolume(Slider slider)
    {
        float val = slider.value;
        sfxAudio.volume = val * 0.08f * 2;
    }

    public void musicVolume(Slider slider)
    {
        float val = slider.value;
        foreach (AudioSource s in musicAudioList)
        {
            s.volume = val * 0.5f * 2;
        }
    }

    public void mixerFadeOut()
    {
        snapFadeOut.TransitionTo(2.5f);
    }
    public void mixerFadeIn()
    {
        snapFadeIn.TransitionTo(1f);
    }
}
