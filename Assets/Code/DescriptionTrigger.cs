using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DescriptionTrigger : MonoBehaviour
{
    public Vector3 mypos, originalPos;
    public GameObject popup,popupdestination;
    public string title, description;
    public int myID;
    public UpgradeRequirements requirements;
    public UpgradesStatus upgrades;
    public GameState gs;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = popup.GetComponent<RectTransform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gs.upgrading)
        {
            mypos = popupdestination.GetComponent<RectTransform>().position;
        }
    }

    public void MouseEnter()
    {
        if (requirements.money[myID] <= upgrades.money && requirements.stars[myID] <= upgrades.stars)
        {
            popup.GetComponent<RectTransform>().position = mypos;
            popup.transform.Find("TitleImage").GetComponentInChildren<TextMeshProUGUI>().text = title;
            popup.transform.Find("TextImage").GetComponentInChildren<TextMeshProUGUI>().text = description;

        }

    }

    public void MouseExit()
    {        
           popup.GetComponent<RectTransform>().position = originalPos;        
    }
}
