using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeSellButton : MonoBehaviour
{
    public UpgradesStatus upgrades;
    public UpgradeRequirements requirements;
    public UpgradeIDs myID;
    Button mybutton;
    protected int costindex;

    private void Start()
    {
        mybutton = this.GetComponent<Button>();
        for (int i = 0; i < requirements.iDs.Count; i++)
        {
            if (requirements.iDs[i] == myID)
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
            case UpgradeIDs.table:
                if(upgrades.tableCount <1)
                {
                    mybutton.interactable = false;
                }
                else
                {
                    mybutton.interactable = true;
                }
                break;
            case UpgradeIDs.snack:
                if (upgrades.snackCount < 1)
                {
                    mybutton.interactable = false;
                }
                else
                {
                    mybutton.interactable = true;
                }
                break;           
        }
    }

    public void OnClick()
    {
        switch (myID)
        {
            case UpgradeIDs.table:
                upgrades.tableCount--;                
                break;
            case UpgradeIDs.snack:
                upgrades.snackCount--;
                break;
        }
        upgrades.money += (int)(requirements.money[costindex] * 0.8f);
    }
}
