using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuCanvas : MonoBehaviour
{
    public Resources res;
    public UpgradesStatus upgrades;
    public Configs configs;
    public void NewGame()
    {
        configs.first = true;
        for (int i = 0; i < res.starsPerStage.Count; i++)
        {
            res.starsPerStage[i] = 0;
        }
        upgrades.money = 0;
        upgrades.tableCount = 0;

        SceneManager.LoadScene("StageTutorial");
    }

    public void LoadGame()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
