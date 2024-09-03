using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public Animator screenFade;

    #region instance
    public static FadeManager instance;

    void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Start()
    {
        screenFade.gameObject.SetActive(true);
    }

    public void Menu_FadeIn(GameObject menuGMB)
    {
        screenFade.SetBool("Fade", true);
        StartCoroutine(Menu_FadeOut(menuGMB));
    }

    private IEnumerator Menu_FadeOut(GameObject menuGMB)
    {
        yield return new WaitForSeconds(1f);
        TooltipManager.instance.HideTooltips();
        MenuManager.instance.Fade_ChangeMenu(menuGMB);
        screenFade.SetBool("Fade", false);
    }
}
