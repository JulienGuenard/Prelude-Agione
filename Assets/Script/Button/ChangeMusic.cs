using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public AudioClip clipOnEnable;

    void OnEnable()
    {
        if (MusicManager.instance == null)                          return;
        if (MusicManager.instance.musicAudio.clip == clipOnEnable)  return;

        MusicManager.instance.musicAudio.clip = clipOnEnable;
        MusicManager.instance.musicAudio.Play();
    }
}
