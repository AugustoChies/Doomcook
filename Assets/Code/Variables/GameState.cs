using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class GameState : ScriptableObject
{
    [Header("Camera")]
    public bool wide;
    [Header("Game")]
    public bool minigame;
    public bool tutorial;
    public bool upgrading;
    public bool end;
    public float timer;
}
