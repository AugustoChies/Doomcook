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
    public TextMeshProUGUI moneytxt, startxt;
    protected int costindex;
    // Start is called before the Sfirst frame update
    void Start()
    {
        mybutton = this.GetComponent<Button>();
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
                    mybutton.interactable = false;
                }
                else
                {
                    mybutton.interactable = true;
                }
                break;
            case UpgradeIDs.strongestwall:
                if (upgrades.wallUpgrade == WallUpgrade.greater)
                {
                    mybutton.interactable = false;
                }
                else
                {
                    mybutton.interactable = true;
                }
                break;
            case UpgradeIDs.autoprep:                
                if (upgrades.prepUpgrade == PrepUpgrade.auto)
                {
                    mybutton.interactable = false;
                }
                else
                {
                    mybutton.interactable = true;
                }
                break;
            case UpgradeIDs.miniprep:
                if (upgrades.prepUpgrade == PrepUpgrade.minigame)
                {
                    mybutton.interactable = false;
                }
                else
                {
                    mybutton.interactable = true;
                }
                break;
            case UpgradeIDs.fastburn:
                if (upgrades.ovenUpgrade == OvenUpgrade.fast)
                {
                    mybutton.interactable = false;
                }
                else
                {
                    mybutton.interactable = true;
                }
                break;
            case UpgradeIDs.noburn:
                if (upgrades.ovenUpgrade == OvenUpgrade.unburning)
                {
                    mybutton.interactable = false;
                }
                else
                {
                    mybutton.interactable = true;
                }
                break;
            case UpgradeIDs.table:
                break;
            case UpgradeIDs.snack:
                break;
            case UpgradeIDs.screen:
                if (upgrades.screens[screenID])
                {
                    //mybutton.interactable = false;
                }
                else
                {
                    mybutton.interactable = true;
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
                if (requirements.money[costindex] <= upgrades.money && requirements.stars[costindex] <= upgrades.stars)
                {
                    upgrades.money -= requirements.money[costindex];

                    upgrades.wallUpgrade = WallUpgrade.great;
                }
                break;
            case UpgradeIDs.strongestwall:
                if (requirements.money[costindex] <= upgrades.money && requirements.stars[costindex] <= upgrades.stars)
                {
                    upgrades.money -= requirements.money[costindex];

                    upgrades.wallUpgrade = WallUpgrade.greater;
                }
                break;
            case UpgradeIDs.autoprep:
                if (requirements.money[costindex] <= upgrades.money && requirements.stars[costindex] <= upgrades.stars)
                {
                    upgrades.money -= requirements.money[costindex];

                    upgrades.prepUpgrade = PrepUpgrade.auto;
                }                
                break;
            case UpgradeIDs.miniprep:
                if (requirements.money[costindex] <= upgrades.money && requirements.stars[costindex] <= upgrades.stars)
                {
                    upgrades.money -= requirements.money[costindex];

                    upgrades.prepUpgrade = PrepUpgrade.minigame;
                }
                break;
            case UpgradeIDs.fastburn:
                if (requirements.money[costindex] <= upgrades.money && requirements.stars[costindex] <= upgrades.stars)
                {
                    upgrades.money -= requirements.money[costindex];

                    upgrades.ovenUpgrade = OvenUpgrade.fast;
                }
                break;
            case UpgradeIDs.noburn:
                if (requirements.money[costindex] <= upgrades.money && requirements.stars[costindex] <= upgrades.stars)
                {
                    upgrades.money -= requirements.money[costindex];

                    upgrades.ovenUpgrade = OvenUpgrade.unburning;
                }
                break;
            case UpgradeIDs.table:
                if (requirements.money[costindex] <= upgrades.money && requirements.stars[costindex] <= upgrades.stars)
                {
                    upgrades.money -= requirements.money[costindex];

                    upgrades.tableCount++;
                }
                break;
            case UpgradeIDs.snack:
                if (requirements.money[costindex] <= upgrades.money && requirements.stars[costindex] <= upgrades.stars)
                {
                    upgrades.money -= requirements.money[costindex];

                    upgrades.snackCount++;
                }
                break;
            case UpgradeIDs.screen:
                if (requirements.money[costindex] <= upgrades.money && requirements.stars[costindex] <= upgrades.stars)
                {
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
                }
                break;
            default:
                break;
        }
    }
}
