using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Animator screenFade;
    public GameObject menuCurrent;
    GameObject previousMenu;
    public GameObject previousGMB;
    public GameObject mangaPanelGMB;
    public GameObject menuOption;

    #region instance
    public static MenuManager instance;

    void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void PreviousMenu()
    {
        screenFade.SetBool("Fade", true);
        StartCoroutine(Fade(previousMenu));
    }
    public void ChangeMenu(GameObject menuGMB)
    {
        if (menuGMB == null) return;

        screenFade.SetBool("Fade", true);
        StartCoroutine(Fade(menuGMB));
    }
    IEnumerator Fade(GameObject menuGMB)
    {
        
        yield return new WaitForSeconds(1f);
        TooltipManager.instance.HideTooltips();
        menuCurrent.SetActive(false);
        menuGMB.SetActive(true);
        previousMenu = menuCurrent;
        menuCurrent = menuGMB;
        if (previousGMB != null) previousGMB.SetActive(true);
        screenFade.SetBool("Fade", false);
    }

    public void NarrativeStart(int id)
    {
        TooltipManager.instance.HideTooltips();
        NarrativeManager.instance.StartNarrative(id);
        mangaPanelGMB.SetActive(true);
    }

    public void NarrativeStop()
    {
        TooltipManager.instance.HideTooltips();
        NarrativeManager.instance.StopNarrative();
        mangaPanelGMB.SetActive(false);
    }

    public void Options()
    {
        menuOption.SetActive(!menuOption.activeInHierarchy);
    }
}
