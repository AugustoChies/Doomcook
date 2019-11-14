using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Give200Bucks : MonoBehaviour
{
    public UpgradesStatus upgrades;
    public Resources stars;
    // Start is called before the first frame update
    void Start()
    {
       if (stars.starsPerStage[0] < 1)
       {
            upgrades.money = 200;
            upgrades.tableCount = 0;
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
