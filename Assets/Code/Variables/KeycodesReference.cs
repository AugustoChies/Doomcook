using System;
using UnityEngine;

[CreateAssetMenu]
public class KeycodesReference : ScriptableObject {

#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    public KeyCode up, down, left, right, interact, alternateminigame, wideCamera,pause;
    
}
