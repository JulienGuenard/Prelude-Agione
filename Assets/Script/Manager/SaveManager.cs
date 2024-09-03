using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public List<Unlock> unlockList;

    #region instance
    public static SaveManager instance;

    void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Start()
    {
        SaveSetup();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) SaveReset();

        CheckUnlockNarrative();
        CheckSave();
    }

    private void CheckUnlockNarrative()
    {
        foreach (Unlock unlock in unlockList)
        {
            if (NarrativeManager.instance.storyID != unlock.narrativeUnlock.storyID) return;
            if (NarrativeManager.instance.narrativeID != unlock.narrativeUnlock.narrativeID) return;

            SetInt(unlock.saveName, 1);
        }
    }
    private void CheckSave()
    {
        foreach (Unlock unlock in unlockList)
        {
            bool unlocked = GetInt(unlock.saveName) == 1;

            unlock.btn_on.SetActive(unlocked);
            unlock.btn_off.SetActive(!unlocked);
        }
    }

    private void SaveReset()
    {
        PlayerPrefs.DeleteAll();
        SaveSetup();
    }
    private void SaveSetup()
    {
        PlayerPrefs.DeleteAll();
        foreach (Unlock unlock in unlockList) if (!PlayerPrefs.HasKey(unlock.saveName)) SetInt(unlock.saveName, 0);
    }

    private void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
        PlayerPrefs.Save();
    }
    private int GetInt(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }
}
