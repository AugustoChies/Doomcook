using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LifeControl : MonoBehaviour {
    public FloatVariable life;
    public Image lifebar;
	// Use this for initialization
	void Start () {
        life.Value = 100;
	}
	
	// Update is called once per frame
	void Update () {
        lifebar.fillAmount = life.Value / 100;
	}
}
