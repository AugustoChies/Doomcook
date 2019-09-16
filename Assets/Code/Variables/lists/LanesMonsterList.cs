using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class LanesMonsterList : ScriptableObject
{
    public List<GameObject> lane1, lane2, lane3;

    public void Setup()
    {
        lane1 = new List<GameObject>();
        lane2 = new List<GameObject>();
        lane3 = new List<GameObject>();
    }
}
