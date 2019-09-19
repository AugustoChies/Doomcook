using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class LanesMonsterList : ScriptableObject
{
    public List<List<GameObject>> lanes;

    public void Setup()
    {
        lanes = new List<List<GameObject>>();
        lanes.Add(new List<GameObject>());
        lanes.Add(new List<GameObject>());
        lanes.Add(new List<GameObject>());
    }
}
