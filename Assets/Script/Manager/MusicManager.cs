using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public AudioSource sfxAudio;
    public List<AudioSource> musicAudioList;
    public AudioMixerSnapshot snapFadeIn, snapFadeOut;

    #region instance
    public static MusicManager instance;

    void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Start()
    {
        snapFadeIn.TransitionTo(0.01f);
    }

    public void OptionSlider_VolumeSFX(Slider slider)
    {
        float val = slider.value;
        sfxAudio.volume = val * 0.08f * 2;
    }
    public void OptionSlider_VolumeMusic(Slider slider)
    {
        float val = slider.value;
        foreach (AudioSource s in musicAudioList)
        {
            s.volume = val * 0.5f * 2;
        }
    }

    public void Btn_MixerIn()
    {
        snapFadeIn.TransitionTo(1f);
    }
    public void Btn_MixerOut()
    {
        snapFadeOut.TransitionTo(2.5f);
    }
}
