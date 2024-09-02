using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableOBJ/NarrativeObj", order = 1)]
public class NarrativeObj : ScriptableObject
{
    public GameObject sceneNarrative;
    public List<DialogStruct> dialogList;
}