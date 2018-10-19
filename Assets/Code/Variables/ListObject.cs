using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class ListObject : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public List<Mesh> list;   
}
