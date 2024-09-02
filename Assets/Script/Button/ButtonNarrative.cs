using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNarrative : MonoBehaviour
{
    public bool startNarrative;
    public int id;

    private void OnMouseDown()
    {
        if (startNarrative) MenuManager.instance.NarrativeStart(id);
        else MenuManager.instance.NarrativeStop();
    }
}
