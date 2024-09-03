using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    public GameObject tooltipGMB_0;
    public TextMeshPro tooltipGMB_0_title, tooltipGMB_0_text;

    public GameObject tooltipGMB_1;
    public TextMeshPro tooltipGMB_1_title, tooltipGMB_1_text;

    public GameObject tooltipGMB_2;
    public TextMeshPro tooltipGMB_2_title, tooltipGMB_2_text;

    #region instance
    public static TooltipManager instance;

    void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion
    public void Btn_ShowTooltip(string title, string text)
    {
        HideTooltips();
        if (text.Length < 2) ShowTooltip(title, text, tooltipGMB_0, tooltipGMB_0_title, tooltipGMB_0_text);
        else if (text.Length < 100) ShowTooltip(title, text, tooltipGMB_1, tooltipGMB_1_title, tooltipGMB_1_text);
        else ShowTooltip(title, text, tooltipGMB_2, tooltipGMB_2_title, tooltipGMB_2_text);
    }
    public void HideTooltips()
    {
        tooltipGMB_0.SetActive(false);
        tooltipGMB_1.SetActive(false);
        tooltipGMB_2.SetActive(false);
    }

    private void ShowTooltip(string title, string text, GameObject gmb, TextMeshPro tooltipTitle, TextMeshPro tooltipText)
    {
        gmb.SetActive(true);
        tooltipTitle.text = title;
        tooltipText.text = text;
    }
}
