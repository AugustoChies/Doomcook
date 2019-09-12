using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LifeControl : MonoBehaviour {
    public FloatVariable life;
    public Image lifebar;
    public float maxLife = 100;
    public UpgradesStatus upgrades;
    public WallUpgrade myupgrade;
    public GameState gs;
    public float normalLife, life1, life2;
	// Use this for initialization
	void Start () {
        life.Value = maxLife;
	}
	
	// Update is called once per frame
	void Update () {
        if (gs.upgrading)
        {
            myupgrade = upgrades.wallUpgrade;
            switch (myupgrade)
            {
                case WallUpgrade.standart:
                    maxLife = normalLife;
                    break;
                case WallUpgrade.great:
                    maxLife = life1;
                    break;
                case WallUpgrade.greater:
                    maxLife = life2;
                    break;
                default:
                    break;
            }
            life.Value = maxLife;
        }
        lifebar.fillAmount = life.Value / maxLife;
	}
}
