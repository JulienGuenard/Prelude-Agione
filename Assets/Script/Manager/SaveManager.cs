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
        CheckUnlockNarrative();
        CheckSave();
    }

    private void CheckUnlockNarrative()
    {
        foreach (Unlock unlock in unlockList)
        {
            if (NarrativeManager.instance.storyID != unlock.narrativeUnlock.storyID) continue;
            if (NarrativeManager.instance.narrativeID != unlock.narrativeUnlock.narrativeID) continue;

            SetInt(unlock.saveName, 1);
        }
    }
    public void CheckUnlockAdaliseGame(int id)
    {
        foreach (Unlock unlock in unlockList)
        {
            if (unlock.adaliseGameUnlock > id || unlock.adaliseGameUnlock == 0) continue;

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
