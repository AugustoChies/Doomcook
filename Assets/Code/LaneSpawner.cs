using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType
{
    zomboid, mole, blaze, flayer
};

[System.Serializable]
public struct MonsterData
{
    public MonsterType type;
    public int foodIndex;
    public float spawnTime;
};
public class LaneSpawner : MonoBehaviour
{
    public LanesMonsterList lanelist;
    public short myLaneIndex;
    public List<MonsterData> monsters;
    public GameState gs;
    public GameObject zonboid, mole, blaze, flayer;
    public float elapsedTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (monsters.Count > 0 && gs.timer >= monsters[0].spawnTime + elapsedTime)
        {
            elapsedTime += monsters[0].spawnTime;
            GameObject mon = null;
            switch (monsters[0].type)
            {
                case MonsterType.zomboid:
                    mon = Instantiate(zonboid, this.transform.position, Quaternion.identity);
                    mon.transform.eulerAngles = new Vector3(0, 90, 0);
                    break;
                case MonsterType.mole:
                    mon = Instantiate(mole, this.transform.position, Quaternion.identity);
                    mon.transform.eulerAngles = new Vector3(0, 90, 0);
                    break;
                case MonsterType.blaze:
                    mon = Instantiate(blaze, this.transform.position, Quaternion.identity);
                    mon.transform.eulerAngles = new Vector3(0, 90, 0);
                    break;
                case MonsterType.flayer:
                    mon = Instantiate(flayer, this.transform.position, Quaternion.identity);
                    mon.transform.eulerAngles = new Vector3(0, 90, 0);
                    break;
            }
            mon.GetComponent<Monster>().SetFood(monsters[0].foodIndex);
            mon.GetComponent<Monster>().myLane = myLaneIndex;
            mon.GetComponent<Monster>().onlist = true;
            monsters.RemoveAt(0);
            
            lanelist.lanes[myLaneIndex - 1].Add(mon);
           
            
        }
    }
}
