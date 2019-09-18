using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : Monster
{
    void Awake()
    {
        moving = false;
        StartCoroutine(Burrow(true));
    }
    void Update()
    {
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
        else if (barred)
        {
            acounter += 1 * Time.deltaTime;
            if (acounter > attackspeed)
            {
                acounter = 0;
                AttackObstacle();
            }
        }
    }

    public override void Attack()
    {
        life.Value -= power;
    }

    public override void AttackObstacle()
    {
        targetedObstacle.life -= power;
    }


    IEnumerator Burrow(bool down)
    {
        if (down)
        {
            while (this.transform.position.y > -0.3f)
            {
                this.transform.position -= transform.up * 2.5f * Time.deltaTime;
                yield return null;
            }
            moving = true;
        }
        else
        {
            while (this.transform.position.y < 2f)
            {
                this.transform.position += transform.up * 2.5f * Time.deltaTime;
                yield return null;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Table")
        {
            StartCoroutine(Burrow(false));
            myTable = other.gameObject;
            atTable = true;
            moving = false;
        }
        else if (other.tag == "Snack")
        {
            if (!ateSnack && !snacking)
            {
                int availableSnacks = other.transform.parent.GetComponent<Snacktable>().availableSnacks;
                availableSnacks--;
                if (availableSnacks < 0) { availableSnacks = 0; }

                snackXPos = other.transform.parent.GetComponent<Snacktable>().snackmodels[7 - availableSnacks].transform.position.x;
                other.transform.parent.GetComponent<Snacktable>().availableSnacks--;
                snacking = true;

                if (other.name == "Lower")
                {
                    up = true;
                }
                else if (other.name == "Upper")
                {
                    up = false;
                }
            }

        }
    }
}
