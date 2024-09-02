using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public AudioSource sfxAudio;
    public List<AudioSource> musicAudioList;

    #region instance
    public static MusicManager instance;

    void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

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
}
