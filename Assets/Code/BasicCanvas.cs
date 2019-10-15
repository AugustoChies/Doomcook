using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BasicCanvas : MonoBehaviour
{
    public Image tablesprite, snacksprite;
    public TextMeshProUGUI tableText, snackText;
    public UpgradesStatus upgrades;
    public GameObject pauseMenu;
    public GameState gs;

    void Update()
    {
        if(upgrades.tableCount > 0)
        {
            tablesprite.enabled = true;
            tableText.enabled = true;
            tableText.text = "x" + upgrades.tableCount;
        }
        else
        {
            tablesprite.enabled = false;
            tableText.enabled = false;
        }

        if (upgrades.snackCount > 0)
        {
            snacksprite.enabled = true;
            snackText.enabled = true;
            snackText.text = "x" + upgrades.snackCount;
        }
        else
        {
            snacksprite.enabled = false;
            snackText.enabled = false;
        }

        if(!gs.tutorial && !gs.upgrading && Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenu.activeSelf)
            {
                Resume();
            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StageMap");
    }
}
