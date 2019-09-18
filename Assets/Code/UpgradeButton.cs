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
        switch (myID)
        {
            case UpgradeIDs.strongwall:
                break;
            case UpgradeIDs.strongestwall:
                break;
            case UpgradeIDs.autoprep:
                moneytxt.text = "" + requirements.money[costindex];
                startxt.text = "" + requirements.stars[costindex];
                if (upgrades.prepUpgrade == PrepUpgrade.auto)
                {
                    mybutton.interactable = false;
                }
                    break;
            case UpgradeIDs.miniprep:
                break;
            case UpgradeIDs.fastburn:
                break;
            case UpgradeIDs.noburn:
                break;
            case UpgradeIDs.table:
                break;
            case UpgradeIDs.snack:
                break;
            case UpgradeIDs.screen:
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


                    upgrades.wallUpgrade = WallUpgrade.great;
                }
                break;
            case UpgradeIDs.strongestwall:
                upgrades.wallUpgrade = WallUpgrade.greater;
                break;
            case UpgradeIDs.autoprep:
                upgrades.prepUpgrade = PrepUpgrade.auto;          
                break;
            case UpgradeIDs.miniprep:
                upgrades.prepUpgrade = PrepUpgrade.minigame;
                break;
            case UpgradeIDs.fastburn:
                break;
            case UpgradeIDs.noburn:
                break;
            case UpgradeIDs.table:
                break;
            case UpgradeIDs.snack:
                break;
            case UpgradeIDs.screen:
                break;
            default:
                break;
        }
    }
}
