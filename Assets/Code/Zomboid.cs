using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zomboid : Monster {
	void Update () {
        if (moving)
        {
            this.transform.position += transform.forward * speed * Time.deltaTime;
        }
        else if (atTable)
        {
            bool eat = false;
            for (int i = 0; i < myTable.GetComponent<Table>().placed.Count; i++)
            {
                if (myTable.GetComponent<Table>().placed[i].Equals(order))
                {
                    eat = true;
                    atTable = false;
                    myTable.GetComponent<Table>().placed[i] = new Food();
                    order = new Food();
                    myTable.GetComponent<Table>().ShowCarriedMesh();
                    ShowCarriedMesh();
                    StartCoroutine("Sink");
                    break;
                }
            }
            if (!eat)
            {
                acounter += 1 * Time.deltaTime;
                if (acounter > attackspeed)
                {
                    acounter = 0;
                    Attack();
                }
            }
        }
    }

    public override void Attack()
    {
        life.Value -= power;
    }
}
