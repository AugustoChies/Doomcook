using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BasicCanvas : MonoBehaviour
{
    public Image tablesprite, snacksprite;
    public TextMeshProUGUI tableText, snackText;
    public UpgradesStatus upgrades;

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
    }
}
