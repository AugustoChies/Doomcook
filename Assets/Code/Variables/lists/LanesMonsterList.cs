using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class LanesMonsterList : ScriptableObject
{
    public List<GameObject>[] lanes;

    public void Setup()
    {
        lanes = new List<GameObject>[3];
        lanes[0] = new List<GameObject>();
        lanes[1] = new List<GameObject>();
        lanes[2] = new List<GameObject>();
    }
}
