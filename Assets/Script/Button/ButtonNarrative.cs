using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNarrative : MonoBehaviour
{
    public bool startNarrative;
    public int storyID;

    private void OnMouseDown()
    {
        if (startNarrative) MenuManager.instance.Btn_NarrativeStart(storyID);
        else                MenuManager.instance.Btn_NarrativeStop();
    }
}
