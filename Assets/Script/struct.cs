using UnityEngine;

[System.Serializable] public struct DialogStruct
{
    public string txt;
    public VoiceObj dialogVoicePreset;
    public AudioClip sfx;
    public float speed;
    public float pitch;
    public float pitchRand;
    public float spaceDelay;
    public float virguleDelay;
    public float pointDelay;
    public float bubbleDelay;
    public int hideNumber;
}
[System.Serializable] public struct NarrativeUnlock
{
    public int storyID;
    public int narrativeID;
}
[System.Serializable] public struct Unlock
{
    public string saveName;
    public NarrativeUnlock narrativeUnlock;
    public GameObject btn_on;
    public GameObject btn_off;
}