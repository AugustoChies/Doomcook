using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMusic : MonoBehaviour
{
    AudioSource mus;
    public GameState gs;
    private void Start()
    {
        mus = this.GetComponent<AudioSource>();
    }
    void Update()
    {
        if(!gs.tutorial && !gs.upgrading)
        {
            if(!mus.isPlaying)
            {
                mus.Play();
            }
        }
    }
}
