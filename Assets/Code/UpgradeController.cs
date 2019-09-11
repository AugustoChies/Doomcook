using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour
{
    public float originalPos;
    public GameObject canvas;
    public GameState gs;
    public UpgradesStatus upgrades;
    public UpgradeRequirements requirements;

    private void Awake()
    {
        canvas = this.transform.Find("UpgradeMenu").gameObject;
        originalPos = canvas.GetComponent<RectTransform>().anchoredPosition.x;
        gs.upgrading = true;
        canvas.SetActive(true);
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

    public void PreparerMinigame()
    {
        upgrades.prepUpgrade = PrepUpgrade.minigame;
    }

    public void PreparerAuto()
    {
        upgrades.prepUpgrade = PrepUpgrade.auto;
    }

    public void OvenBurner()
    {
        upgrades.ovenUpgrade = OvenUpgrade.fast;
    }

    public void OvenUnburner()
    {
        upgrades.ovenUpgrade = OvenUpgrade.unburning;
    }

    public void StrongerWall()
    {
        upgrades.wallUpgrade = WallUpgrade.great;
    }

    public void StrongestWall()
    {
        upgrades.wallUpgrade = WallUpgrade.greater;
    }
}
