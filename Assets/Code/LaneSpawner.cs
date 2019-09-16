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

    // Update is called once per frame
    void Update()
    {
        if (monsters.Count > 0 && gs.timer >= monsters[0].spawnTime)
        {
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
            monsters.RemoveAt(0);
            switch (myLaneIndex)
            {
                case 1:
                    lanelist.lane1.Add(mon);
                    break;
                case 2:
                    lanelist.lane2.Add(mon);
                    break;
                case 3:
                    lanelist.lane3.Add(mon);
                    break;
                default:
                    break;
            }
        }
    }
}
