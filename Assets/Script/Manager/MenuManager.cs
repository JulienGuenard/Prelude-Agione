using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Animator screenFade;
    public GameObject menuCurrent, previousGMB, mangaPanelGMB, menuOption;

    GameObject previousMenu;

    #region instance
    public static MenuManager instance;

    void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void Btn_ChangeMenu(GameObject menuGMB)
    {
        if (menuGMB == null) return;

        FadeManager.instance.Menu_FadeIn(menuGMB);
    }
    public void Btn_NarrativeStart(int id)
    {
        TooltipManager.instance.HideTooltips();
        NarrativeManager.instance.StartNarrative(id);
        mangaPanelGMB.SetActive(true);
    }
    public void Btn_NarrativeStop()
    {
        TooltipManager.instance.HideTooltips();
        NarrativeManager.instance.StopNarrative();
        mangaPanelGMB.SetActive(false);
    }
    public void BtnCanvas_ShowOptions()
    {
        menuOption.SetActive(!menuOption.activeInHierarchy);
    }
    public void BtnCanvas_SwitchFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void Fade_ChangeMenu(GameObject menuGMB)
    {
        menuCurrent.SetActive(false);
        menuGMB.SetActive(true);
        previousMenu = menuCurrent;
        menuCurrent = menuGMB;
        if (previousGMB != null) previousGMB.SetActive(true);
    }
}
