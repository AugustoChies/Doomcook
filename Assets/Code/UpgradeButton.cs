using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    public UpgradesStatus upgrades;
    public UpgradeRequirements requirements;
    public UpgradeIDs myID;
    public short screenID;
    Button mybutton;
    GameObject sellImage;
    public TextMeshProUGUI moneytxt, startxt;
    protected int costindex;
    // Start is called before the Sfirst frame update
    void Start()
    {
        mybutton = this.GetComponent<Button>();
        if (myID != UpgradeIDs.table && myID != UpgradeIDs.snack)
        {
            sellImage = this.transform.parent.Find("SellImage").gameObject;
        }
        for (int i = 0; i < requirements.iDs.Count; i++)
        {
            if(requirements.iDs[i] == myID)
            {
                costindex = i;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        moneytxt.text = "" + requirements.money[costindex];
        startxt.text = "" + requirements.stars[costindex];
        switch (myID)
        {
            case UpgradeIDs.strongwall:
                if (upgrades.wallUpgrade == WallUpgrade.great)
                {
                    sellImage.SetActive(true);
                }
                else
                {
                    sellImage.SetActive(false);
                    if(requirements.money[costindex] < upgrades.money || requirements.stars[costindex] < upgrades.stars)
                    {
                        mybutton.interactable = false;
                    }
                    else
                    {
                        mybutton.interactable = true;
                    }
                }
                break;
            case UpgradeIDs.strongestwall:
                if (upgrades.wallUpgrade == WallUpgrade.greater)
                {
                    sellImage.SetActive(true);
                }
                else
                {
                    sellImage.SetActive(false);
                    if (requirements.money[costindex] < upgrades.money || requirements.stars[costindex] < upgrades.stars)
                    {
                        Debug.Log("in" +this.name);

                        mybutton.interactable = false;
                    }
                    else
                    {
                        Debug.Log("out" + " " + costindex);

                        mybutton.interactable = true;
                    }
                }
                break;
            case UpgradeIDs.autoprep:                
                if (upgrades.prepUpgrade == PrepUpgrade.auto)
                {
                    sellImage.SetActive(true);
                }
                else
                {
                    sellImage.SetActive(false);
                    if (requirements.money[costindex] < upgrades.money || requirements.stars[costindex] < upgrades.stars)
                    {
                        mybutton.interactable = false;
                    }
                    else
                    {
                        mybutton.interactable = true;
                    }
                }
                break;
            case UpgradeIDs.miniprep:
                if (upgrades.prepUpgrade == PrepUpgrade.minigame)
                {
                    sellImage.SetActive(true);
                }
                else
                {
                    sellImage.SetActive(false);
                    if (requirements.money[costindex] < upgrades.money || requirements.stars[costindex] < upgrades.stars)
                    {
                        mybutton.interactable = false;
                    }
                    else
                    {
                        mybutton.interactable = true;
                    }
                }
                break;
            case UpgradeIDs.fastburn:
                if (upgrades.ovenUpgrade == OvenUpgrade.fast)
                {
                    sellImage.SetActive(true);
                }
                else
                {
                    sellImage.SetActive(false);
                    if (requirements.money[costindex] < upgrades.money || requirements.stars[costindex] < upgrades.stars)
                    {
                        mybutton.interactable = false;
                    }
                    else
                    {
                        mybutton.interactable = true;
                    }
                }
                break;
            case UpgradeIDs.noburn:
                if (upgrades.ovenUpgrade == OvenUpgrade.unburning)
                {
                    sellImage.SetActive(true);
                }
                else
                {
                    sellImage.SetActive(false);
                    if (requirements.money[costindex] < upgrades.money || requirements.stars[costindex] < upgrades.stars)
                    {
                        mybutton.interactable = false;
                    }
                    else
                    {
                        mybutton.interactable = true;
                    }
                }
                break;
            case UpgradeIDs.table:
                if (requirements.money[costindex] < upgrades.money || requirements.stars[costindex] < upgrades.stars)
                {
                    mybutton.interactable = false;
                }
                else
                {
                    mybutton.interactable = true;
                }
                break;
            case UpgradeIDs.snack:
                if (requirements.money[costindex] < upgrades.money || requirements.stars[costindex] < upgrades.stars)
                {
                    mybutton.interactable = false;
                }
                else
                {
                    mybutton.interactable = true;
                }
                break;
            case UpgradeIDs.screen:
                if (upgrades.screens[screenID])
                {
                    sellImage.SetActive(true);
                }
                else
                {
                    sellImage.SetActive(false);
                    if (requirements.money[costindex] < upgrades.money || requirements.stars[costindex] < upgrades.stars)
                    {
                        mybutton.interactable = false;
                    }
                    else
                    {
                        mybutton.interactable = true;
                    }
                }
                break;
            default:
                break;
        }
        
    }

    public void OnClick()
    {
        switch (myID)
        {
            case UpgradeIDs.strongwall:
                if (upgrades.wallUpgrade == WallUpgrade.great)
                {
                    upgrades.money += (int)(requirements.money[costindex] * 0.8f);

                    upgrades.wallUpgrade = WallUpgrade.standart;
                }
                else
                {
                    upgrades.money -= requirements.money[costindex];

                    upgrades.wallUpgrade = WallUpgrade.great;
                }
                break;
            case UpgradeIDs.strongestwall:
                if (upgrades.wallUpgrade == WallUpgrade.greater)
                {
                    upgrades.money += (int)(requirements.money[costindex] * 0.8f);

                    upgrades.wallUpgrade = WallUpgrade.standart;
                }
                else
                {
                    upgrades.money -= requirements.money[costindex];

                    upgrades.wallUpgrade = WallUpgrade.greater;
                }
                break;
            case UpgradeIDs.autoprep:
                if (upgrades.prepUpgrade == PrepUpgrade.auto)
                {
                    upgrades.money += (int)(requirements.money[costindex] * 0.8f);

                    upgrades.prepUpgrade = PrepUpgrade.standart;
                }
                else
                {
                    upgrades.money -= requirements.money[costindex];

                    upgrades.prepUpgrade = PrepUpgrade.auto;
                }
                break;
            case UpgradeIDs.miniprep:
                if (upgrades.prepUpgrade == PrepUpgrade.minigame)
                {
                    upgrades.money += (int)(requirements.money[costindex] * 0.8f);

                    upgrades.prepUpgrade = PrepUpgrade.standart;
                }
                else
                {
                    upgrades.money -= requirements.money[costindex];

                    upgrades.prepUpgrade = PrepUpgrade.minigame;
                }
                break;
            case UpgradeIDs.fastburn:
                if (upgrades.ovenUpgrade == OvenUpgrade.fast)
                {
                    upgrades.money += (int)(requirements.money[costindex] * 0.8f);

                    upgrades.ovenUpgrade = OvenUpgrade.standart;
                }
                else
                {
                    upgrades.money -= requirements.money[costindex];

                    upgrades.ovenUpgrade = OvenUpgrade.fast;
                }
                break;
            case UpgradeIDs.noburn:
                if (upgrades.ovenUpgrade == OvenUpgrade.unburning)
                {
                    upgrades.money += (int)(requirements.money[costindex] * 0.8f);

                    upgrades.ovenUpgrade = OvenUpgrade.standart;
                }
                else
                {
                    upgrades.money -= requirements.money[costindex];

                    upgrades.ovenUpgrade = OvenUpgrade.unburning;
                }
                break;
            case UpgradeIDs.table:                
                    upgrades.money -= requirements.money[costindex];

                    upgrades.tableCount++;                
                break;
            case UpgradeIDs.snack:                
                    upgrades.money -= requirements.money[costindex];
                    upgrades.snackCount++;                
                break;
            case UpgradeIDs.screen:
                
                    if (!upgrades.screens[screenID])
                    {
                        upgrades.money -= requirements.money[costindex];

                        upgrades.screens[screenID] = true;
                    }
                    else
                    {
                        upgrades.money += (int)(requirements.money[costindex] * 0.8f);

                        upgrades.screens[screenID] = false;
                    }
                
                break;
            default:
                break;
        }
    }
}
