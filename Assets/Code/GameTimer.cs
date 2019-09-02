using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameTimer : MonoBehaviour
{
    public GameState gs;
    private void Start()
    {
        gs.timer = 0;
    }

    void Update()
    {
        gs.timer += Time.deltaTime;
    }
}
