using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType
{
    zomboid,mole,blaze,flayer
};

public struct MonsterData
{
    MonsterType type;
    int foodIndex;
    float spawnTime;
};
public class LaneSpawner : MonoBehaviour
{
    public List<MonsterData> monsters;
    public GameState gs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
