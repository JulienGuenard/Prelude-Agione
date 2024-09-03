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

    bool isAlterned = false;

    #region instance
    public static BubbleMachineManager instance;

    void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Start()
    {
        audioClipCurrent = audioCliplist[0];
    }

    public void Btn_CreateBubble()
    {
        Vector3 pos = new Vector3(Random.Range(14, 21), -11, 0);
        if (isAlterned) pos = new Vector3(Random.Range(0, 8), -11, 0);

        GameObject obj = Instantiate(bubbleGMB, pos, Quaternion.identity);

        isAlterned = !isAlterned;

        StartCoroutine(WriteBubble(obj));
    }
    public void Droplist_ChangeSFX(TMP_Dropdown drop)
    {
        audioClipCurrent = audioCliplist[drop.value];
    }

    IEnumerator WriteBubble(GameObject obj)
    {
        TextMeshPro txtmesh = obj.gameObject.GetComponentInChildren<TextMeshPro>();
        SpriteRenderer spriteR = obj.gameObject.GetComponentInChildren<SpriteRenderer>();
        spriteR.flipX = !isAlterned;

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

        StartCoroutine(DestroyBubble(obj, txtmesh, spriteR));
    }
    IEnumerator DestroyBubble(GameObject obj, TextMeshPro txtmesh, SpriteRenderer spriteR)
    {
        yield return new WaitForSeconds(2f);
        for(int i = 1; i < 100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            spriteR.color -= new Color(0, 0, 0, 0.01f);
            txtmesh.color -= new Color(0, 0, 0, 0.01f);
        }
        Destroy(obj);
    }
}
