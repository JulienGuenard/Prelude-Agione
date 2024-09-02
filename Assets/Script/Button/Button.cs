using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject menuGMB;
    public bool musicFadeOut;
    public bool musicFadeIn;

    private void OnMouseDown()
    {
        MenuManager.instance.ChangeMenu(menuGMB);

        if (musicFadeOut) MusicManager.instance.mixerFadeOut();
        if (musicFadeIn) MusicManager.instance.mixerFadeIn();
    }
}
