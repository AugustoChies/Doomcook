using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadCode : MonoBehaviour
{
    public Resources resources;
    public UpgradesStatus upgrades;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Money"))
        {
            this.GetComponent<Button>().interactable = true;
        }
        else
        {
            this.GetComponent<Button>().interactable = false;
        }
    }

    public void LoadGame()
    {        
        int [] stars = new int[9];
        for (int i = 0; i < 9; i++)
        {
            stars[i] = PlayerPrefs.GetInt("Star" + i);
        }

        int money = PlayerPrefs.GetInt("Money");
        int ovenstatus = PlayerPrefs.GetInt("Oven");
        int wallstatus = PlayerPrefs.GetInt("Wall");
        int prepstatus = PlayerPrefs.GetInt("Peparer");
        int tables = PlayerPrefs.GetInt("Tables");
        int snacks = PlayerPrefs.GetInt("Snacks");
        int screen0 = PlayerPrefs.GetInt("Screen0");
        int screen1 = PlayerPrefs.GetInt("Screen1");
        int screen2 = PlayerPrefs.GetInt("Screen2");

        for (int i = 0; i < 9; i++)
        {
            resources.starsPerStage[i] = stars[i];
        }

        upgrades.money = money;
        upgrades.ovenUpgrade = (OvenUpgrade)ovenstatus;
        upgrades.wallUpgrade = (WallUpgrade)wallstatus;
        upgrades.prepUpgrade = (PrepUpgrade)prepstatus;
        upgrades.tableCount = tables;
        upgrades.snackCount = snacks;
        upgrades.screens[0] = screen0 != 0;
        upgrades.screens[1] = screen1 != 0;
        upgrades.screens[2] = screen2 != 0;

        SceneManager.LoadScene("StageMap");
    }
}
