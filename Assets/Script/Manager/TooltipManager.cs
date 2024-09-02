using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    public GameObject tooltipGMB_0;
    public TextMeshPro tooltipGMB_0_title;
    public TextMeshPro tooltipGMB_0_text;

    public GameObject tooltipGMB_1;
    public TextMeshPro tooltipGMB_1_title;
    public TextMeshPro tooltipGMB_1_text;

    public GameObject tooltipGMB_2;
    public TextMeshPro tooltipGMB_2_title;
    public TextMeshPro tooltipGMB_2_text;

    #region instance
    public static TooltipManager instance;

    void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void Tooltip(string title, string text)
    {
        if (text.Length < 2) Tooltip_0(title, text);
        else if (text.Length < 100) Tooltip_1(title, text);
        else Tooltip_2(title, text);
    }

    void Tooltip_0(string title, string text)
    {
        tooltipGMB_0.SetActive(true);
        tooltipGMB_0_title.text = title;
        tooltipGMB_0_text.text = text;
    }

    void Tooltip_1(string title, string text)
    {
        tooltipGMB_1.SetActive(true);
        tooltipGMB_1_title.text = title;
        tooltipGMB_1_text.text = text;
    }

    void Tooltip_2(string title, string text)
    {
        tooltipGMB_2.SetActive(true);
        tooltipGMB_2_title.text = title;
        tooltipGMB_2_text.text = text;
    }

    public void HideTooltips()
    {
        tooltipGMB_0.SetActive(false);
        tooltipGMB_1.SetActive(false);
        tooltipGMB_2.SetActive(false);
    }
}
