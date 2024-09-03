using UnityEngine;

[System.Serializable] public struct DialogStruct
{
    public string txt;
    public VoiceObj dialogVoicePreset;
    public AudioClip sfx;
    public float speed, pitch, pitchRand, spaceDelay, virguleDelay, pointDelay, bubbleDelay;
    public int hideNumber;
}
[System.Serializable] public struct NarrativeUnlock
{
    public int storyID, narrativeID;
}
[System.Serializable] public struct Unlock
{
    public string saveName;
    public NarrativeUnlock narrativeUnlock;
    public GameObject btn_on, btn_off;
}