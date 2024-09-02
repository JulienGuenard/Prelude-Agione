using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject menuGMB;

    private void OnMouseDown()
    {
        MenuManager.instance.ChangeMenu(menuGMB);
    }
}
