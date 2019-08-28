using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float life;
    public List<Monster> barredMons;

    // Update is called once per frame
    void Update()
    {
        if(life < 0)
        {
            foreach (Monster m in barredMons)
            {
                m.barred = false;
                m.moving = true;
            }
            Destroy(this.gameObject);
        }
    }
}
