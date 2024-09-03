using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NarrativeManager : MonoBehaviour
{
    public int storyID;
    public int narrativeID; int NarrativeID
    {
        get { return narrativeID; }
        set
        {
            narrativeID = value;
            NarrativeActive = narrativeObjList[narrativeID];
        }
    }

    public bool isPlayed; bool IsPlayed
    {
        get { return isPlayed; }
        set
        {
            isPlayed = value;
            playGMB.SetActive(!isPlayed);
            pauseGMB.SetActive(isPlayed);
        }
    }
    public GameObject playGMB, pauseGMB;

    public Animator screenFade;

    GameObject sceneNarrativeGMB;

    public  List<NarrativeObj> storyAdalise, storyGideon;
    private List<NarrativeObj> narrativeObjList = new List<NarrativeObj>();
    
    NarrativeObj narrativeActive; NarrativeObj NarrativeActive 
    {  
        get { return narrativeActive; } 
        set 
        {
            narrativeActive = value;
            NewNarrative();
        }
    }

    List<TextMeshPro> bubbleList = new List<TextMeshPro>();
    List<Animator> hidingList = new List<Animator>();

    #region instance
    public static NarrativeManager instance;

    void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void StartNarrative(int id)
    {
        narrativeObjList.Clear();
        storyID = id;

        if (id == 0) narrativeObjList.AddRange(storyAdalise);
        if (id == 1) narrativeObjList.AddRange(storyGideon);

        narrativeID += -1;
        Next();
    }

    public void StopNarrative()
    {
        narrativeID = 0;
        IsPlayed = false;
        StopAllCoroutines();
        Destroy(sceneNarrativeGMB);
    }

    void NewNarrative()
    {
        NewNarrative_Scene();
        NewNarrative_DialogReset();
        StopAllCoroutines();
        StartCoroutine(NewNarrative_DialogPlay());
    }
    void NewNarrative_Scene()
    {
        Destroy(sceneNarrativeGMB);
        sceneNarrativeGMB = Instantiate(NarrativeActive.sceneNarrative, Vector3.zero, Quaternion.identity);
    }
    void NewNarrative_DialogReset()
    {
        bubbleList.Clear();
        foreach (TextMeshPro txtMesh in sceneNarrativeGMB.GetComponentsInChildren<TextMeshPro>())
        {
            bubbleList.Add(txtMesh);
            txtMesh.text = " ";
        }

        hidingList.Clear();
        foreach (Animator hid in sceneNarrativeGMB.GetComponentsInChildren<Animator>())
        {
            hidingList.Add(hid);
            hid.SetBool("Fade", false);
        }
    }
    IEnumerator NewNarrative_DialogPlay()
    {
        yield return new WaitForSeconds(1.25f);
        for(int i = 0; i < bubbleList.Count; i++)
        {
            string txt = narrativeActive.dialogList[i].txt;
            VoiceObj voice = narrativeActive.dialogList[i].dialogVoicePreset;
            DialogStruct dialog;

            if (voice == null)  dialog = narrativeActive.dialogList[i];
            else                dialog = narrativeActive.dialogList[i].dialogVoicePreset.dialogStruct;

            AudioClip sfx = dialog.sfx;
            float pitch = dialog.pitch;
            float pitchRand = dialog.pitchRand;
            float speed = dialog.speed;
            float spaceDelay = dialog.spaceDelay;
            float virguleDelay = dialog.virguleDelay;
            float pointDelay = dialog.pointDelay;
            float bubbleDelay = dialog.bubbleDelay;
            int hideNumber = narrativeActive.dialogList[i].hideNumber;

            for (int x = 1; x < txt.Length + 1; x++)
            {
                yield return new WaitForSeconds(speed);

                if (txt.Substring(x).StartsWith("<")) 
                {
                    x += 4;
                    yield return new WaitForSeconds(0.1f);
                    continue;
                }

                bubbleList[i].text = txt.Insert(x, "<color=#00000000>");
                MusicManager.instance.sfxAudio.pitch = Random.Range(pitch - pitchRand, pitch + pitchRand);

                if (txt.Substring(x-1).StartsWith(" "))
                {
                    yield return new WaitForSeconds(spaceDelay);
                    continue;
                }
                if (txt.Substring(x-1).StartsWith(","))
                {
                    yield return new WaitForSeconds(virguleDelay);
                    continue;
                }
                if (txt.Substring(x-1).StartsWith("."))
                {
                    yield return new WaitForSeconds(pointDelay);
                    continue;
                }
                if (x >= txt.Length) continue;

                MusicManager.instance.sfxAudio.PlayOneShot(sfx);
            }
            if (hideNumber > 0)
            {
                for (int x = 0; x < hideNumber; x++)
                {
                    hidingList[x].SetBool("Fade", true);
                }
                hidingList.RemoveRange(0, hideNumber);
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(bubbleDelay);
        }
        if (isPlayed) Next();
    }

    public void Next()
    {
        if (narrativeID + 1 >= narrativeObjList.Count) return;

        screenFade.SetBool("Fade", true);
        StartCoroutine(NextWaitForFade());
    }
    IEnumerator NextWaitForFade()
    {
        yield return new WaitForSeconds(1f);
        NarrativeID++;
        screenFade.SetBool("Fade", false);
    }

    public void Previous()
    {
        if (narrativeID <= 0) return;

        screenFade.SetBool("Fade", true);
        StartCoroutine(PreviousWaitForFade());
    }
    IEnumerator PreviousWaitForFade()
    {
        yield return new WaitForSeconds(1f);
        NarrativeID--;
        screenFade.SetBool("Fade", false);
    }

    public void BtnCanvas_NarrativeAutoPlay(bool state) { IsPlayed = state; }
}


