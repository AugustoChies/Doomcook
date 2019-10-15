using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UpgradeController : MonoBehaviour
{
    public float originalPos;
    public GameObject canvas;
    public GameObject[] screens;
    public GameState gs;
    public Configs configs;
    public UpgradesStatus upgrades;
    public UpgradeRequirements requirements;

    private void Awake()
    {
        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(upgrades.screens[i]);
        }
        canvas = this.transform.Find("UpgradeMenu").gameObject;
        originalPos = canvas.GetComponent<RectTransform>().anchoredPosition.x;
        canvas.SetActive(true);
        if(configs.first && SceneManager.GetActiveScene().name == "Stage0")
        {
            upgrades.money += 200;
            configs.first = false;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if(gs.upgrading)
        {
            if(canvas.GetComponent<RectTransform>().anchoredPosition.x > 0)
            {
                canvas.GetComponent<RectTransform>().anchoredPosition -= new Vector2(1800 * Time.deltaTime, 0);
            }
            else if (canvas.GetComponent<RectTransform>().anchoredPosition.x < 0)
            {
                canvas.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            }

            for (int i = 0; i < screens.Length; i++)
            {
                screens[i].SetActive(upgrades.screens[i]);
            }
        }
        else
        {
            if (canvas.GetComponent<RectTransform>().anchoredPosition.x < originalPos)
            {
                canvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(2400 * Time.deltaTime, 0);
            }           
        }
    }

    public void DoneButton()
    {
        gs.upgrading = false;
    } 
  
}
