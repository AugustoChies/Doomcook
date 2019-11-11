using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UpgradeController : MonoBehaviour
{
    public float originalPos;
    public GameObject canvas;
    public GameObject[] screens;
    public GameState gs;
    public UpgradesStatus upgrades;
    public UpgradeRequirements requirements;
    TextMeshProUGUI textMoney,textStar;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Stage0")
        {
            screens[0].SetActive(upgrades.screens[0]);
        }
        else
        {
            for (int i = 0; i < screens.Length; i++)
            {
                screens[i].SetActive(upgrades.screens[i]);
            }
        }
        canvas = this.transform.Find("UpgradeMenu").gameObject;
        originalPos = canvas.GetComponent<RectTransform>().anchoredPosition.x;
        canvas.SetActive(true);
        
        textMoney = transform.Find("UpgradeMenu/MoneyImage").GetComponentInChildren<TextMeshProUGUI>();
        textStar = transform.Find("UpgradeMenu/StarImage").GetComponentInChildren<TextMeshProUGUI>();
        textStar.text = "" + upgrades.stars;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(gs.upgrading)
        {
            textMoney.text = "" + upgrades.money;            

            if (canvas.GetComponent<RectTransform>().anchoredPosition.x > 0)
            {
                canvas.GetComponent<RectTransform>().anchoredPosition -= new Vector2(1800 * Time.deltaTime, 0);
            }
            else if (canvas.GetComponent<RectTransform>().anchoredPosition.x < 0)
            {
                canvas.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            }

            if (SceneManager.GetActiveScene().name == "Stage0")
            {
                screens[0].SetActive(upgrades.screens[0]);
            }
            else
            {
                for (int i = 0; i < screens.Length; i++)
                {
                    screens[i].SetActive(upgrades.screens[i]);
                }
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
