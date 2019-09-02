using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SetupStage : MonoBehaviour
{
    public LaneSpawner[] lanes;
    public int currentStage;
    
    // Start is called before the first frame update
    void Awake()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Setup()
    {
        string path = Application.streamingAssetsPath + "Stage" + currentStage + ".txt";
        StreamReader stream = new StreamReader(path);
        string text;
        while (!stream.EndOfStream)
        {
            text = stream.ReadLine();
        }
       
        stream.Close();
        
        
       
    }
}
