using System;
using UnityEngine;

[CreateAssetMenu]
public class BoolReference : ScriptableObject {
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public bool Value;	
}
