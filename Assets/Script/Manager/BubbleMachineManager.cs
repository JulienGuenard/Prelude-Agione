using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class BubbleMachineManager : MonoBehaviour
{
    public GameObject bubbleGMB;
    public TextMeshProUGUI textM;
    public Slider pitchM, pitchRandM, speedM, spaceDelayM, virguleDelayM, pointDelayM, bubbleDelayM;
    public List<AudioClip> audioCliplist;
    private AudioClip audioClipCurrent;

    #region instance
    public static BubbleMachineManager instance;

    void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Start()
    {
        Droplist_ChangeSFX(0);
    }

    public void Btn_CreateBubble()
    {
        Vector3 pos = new Vector3(14, -8, 0);
        GameObject obj = Instantiate(bubbleGMB, pos, Quaternion.identity);
        StartCoroutine(WriteBubble(obj));
        StartCoroutine(DestroyBubble(obj));
    }

    public void Droplist_ChangeSFX(int id)
    {
        audioClipCurrent = audioCliplist[id];
    }

    IEnumerator WriteBubble(GameObject obj)
    {
        TextMeshPro txtmesh = obj.gameObject.GetComponentInChildren<TextMeshPro>();
        

        string txt = textM.text;
        txtmesh.text = txt.Insert(0, "<color=#00000000>");

        AudioClip sfx = audioClipCurrent;

        float pitch = pitchM.value;
        float pitchRand = pitchRandM.value;
        float speed = speedM.value;
        float spaceDelay = spaceDelayM.value;
        float virguleDelay = virguleDelayM.value;
        float pointDelay = pointDelayM.value;
        float bubbleDelay = bubbleDelayM.value;

        for (int x = 1; x < txt.Length + 1; x++)
        {
            yield return new WaitForSeconds(speed);

            if (txt.Substring(x).StartsWith("<"))
            {
                x += 4;
                yield return new WaitForSeconds(0.1f);
                continue;
            }

            txtmesh.text = txt.Insert(x, "<color=#00000000>");
            MusicManager.instance.sfxAudio.pitch = Random.Range(pitch - pitchRand, pitch + pitchRand);

            if (txt.Substring(x - 1).StartsWith(" "))
            {
                yield return new WaitForSeconds(spaceDelay);
                continue;
            }
            if (txt.Substring(x - 1).StartsWith(","))
            {
                yield return new WaitForSeconds(virguleDelay);
                continue;
            }
            if (txt.Substring(x - 1).StartsWith("."))
            {
                yield return new WaitForSeconds(pointDelay);
                continue;
            }
            if (x >= txt.Length) continue;

            MusicManager.instance.sfxAudio.PlayOneShot(sfx);
        }
    }

    IEnumerator DestroyBubble(GameObject obj)
    {
        yield return new WaitForSeconds(2f);
        Destroy(obj);
    }
}
