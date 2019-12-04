using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float timer;

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.name.Contains("DustCircle"))
        {
            if(timer < 3)
            {
                this.GetComponent<AudioSource>().Stop();
            }
        }
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
