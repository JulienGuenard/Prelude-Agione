using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableLink : MonoBehaviour
{
    public GameObject gmbToLink;

    void OnEnable()
    {
        gmbToLink.SetActive(true);
    }

    void OnDisable()
    {
        gmbToLink.SetActive(false);
    }
}
