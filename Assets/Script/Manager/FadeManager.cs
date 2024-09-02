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
}
