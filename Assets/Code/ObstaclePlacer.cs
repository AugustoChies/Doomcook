using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePlacer : MonoBehaviour
{
    public UpgradesStatus upgrades;
    public UpgradeIDs myID;
    public GameObject myprefab;
    GameObject myinst;
    
    // Update is called once per frame
    void Update()
    {
        if(myID == UpgradeIDs.table)
        {
            if (myinst || upgrades.tableCount < 1)
            {
                this.GetComponent<Collider>().enabled = false;
                this.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                this.GetComponent<Collider>().enabled = true;
                this.GetComponent<Renderer>().enabled = true;
            }
        }
        else if (myID == UpgradeIDs.snack)
        {
            if(myinst || upgrades.snackCount < 1)
            {
                this.GetComponent<Collider>().enabled = false;
                this.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                this.GetComponent<Collider>().enabled = true;
                this.GetComponent<Renderer>().enabled = true;
            }
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {          
            myinst = Instantiate(myprefab, this.transform.position, this.transform.rotation);
            if (myID == UpgradeIDs.table)
            {
                upgrades.tableCount--;
            }
            else if (myID == UpgradeIDs.snack)
            {
                upgrades.snackCount--;
            }
            
        }
    }
}
