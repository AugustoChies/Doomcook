 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingText : MonoBehaviour
{
    public float speed;
    bool up = true;
    float time = 0.8f;
    // Update is called once per frame
    void Update()
    {
        if(up)
        {
            if(time > 0)
            {
                time -= Time.deltaTime;
                this.transform.localPosition += new Vector3(0, speed * Time.deltaTime, 0);
            }
            else
            {
                up = false;
                time = 0.8f;
            }

        }
        else
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                this.transform.localPosition -= new Vector3(0, speed * Time.deltaTime, 0);
            }
            else
            {
                up = true;
                time = 0.8f;
            }
        }
    }
}
