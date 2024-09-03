using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
                public string title;
    [TextArea]  public string text;

    public void OnMouseEnter()
    {
        TooltipManager.instance.Tooltip(title, text);
    }

    public void OnMouseExit()
    {
        TooltipManager.instance.HideTooltips();
    }
}
