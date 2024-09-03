using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject menuGMB;
    public bool musicFadeOut, musicFadeIn;

    private void OnMouseDown()
    {
        MenuManager.instance.Btn_ChangeMenu(menuGMB);

        if (musicFadeOut)   MusicManager.instance.Btn_MixerOut();
        if (musicFadeIn)    MusicManager.instance.Btn_MixerIn();
    }
}
