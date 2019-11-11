using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SetupStage : MonoBehaviour
{
    public LanesMonsterList laneList;
    public LaneSpawner[] lanes;
    public int currentStage;
    public float elapsedTime = 0;

    // Start is called before the first frame update
    void Awake()
    {
        laneList.Setup();
        Setup();
    }


    void Setup()
    {
        string path = Application.streamingAssetsPath + "/Stages/Stage" + currentStage + ".txt";
        StreamReader stream = new StreamReader(path);
        string[] text;
        while (!stream.EndOfStream)
        {
            text = stream.ReadLine().Split(' ');
            LaneSpawner currentlane = null;
            switch (text[0])
            {
                case "1":
                    currentlane = lanes[0];
                    break;
                case "2":
                    currentlane = lanes[1];
                    break;
                case "3":
                    currentlane = lanes[2];
                    break;
                case "4":
                    currentlane = lanes[3];
                    break;
                case "5":
                    currentlane = lanes[4];
                    break;
                default:
                    break;
            }
            MonsterData md = new MonsterData();
            MonsterType type = MonsterType.zomboid;

            switch (text[1])
            {
                case "zon":
                    type = MonsterType.zomboid;
                    break;
                case "mol":
                    type = MonsterType.mole;
                    break;
                case "bla":
                    type = MonsterType.blaze;
                    break;
                case "fla":
                    type = MonsterType.flayer;
                    break;                
                default:
                    break;
            }
            md.type = type;
            md.spawnTime = float.Parse(text[2]) + elapsedTime;
            elapsedTime += float.Parse(text[2]);
            md.foodIndex = int.Parse(text[3]);
            currentlane.monsters.Add(md);
        }
       
        stream.Close();
        
        
       
    }
}
