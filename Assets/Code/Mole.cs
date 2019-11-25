using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : Monster
{
    bool underground;
    void Awake()
    {
        moving = true;
        StartCoroutine(Burrow(true));
    }
    void Update()
    {
        anim.SetBool("Moving", false);
        anim.SetBool("Snacking", false);
        if (moving)
        {
            anim.SetBool("Moving", true);
            this.transform.position += transform.forward * speed * Time.deltaTime;
        }
        else if (atTable && !underground)
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
            if (!eat && !underground)
            {
                acounter += 1 * Time.deltaTime;
                if (acounter > attackspeed)
                {
                    acounter = 0;
                    anim.SetTrigger("Attack");
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
                anim.SetTrigger("Attack");
                AttackObstacle();
            }
        }

        iconMaster.transform.rotation = rotation;

    }

    public override void Attack()
    {
        StartCoroutine(WaitAttack());
    }

    public override void AttackObstacle()
    {
        StartCoroutine(WaitAttackObstacle());
    }

    IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(0.8f);
        life.Value -= power;
    }

    IEnumerator WaitAttackObstacle()
    {
        yield return new WaitForSeconds(0.8f);
        targetedObstacle.life -= power;
    }

    IEnumerator Burrow(bool down)
    {        
        if (down)
        {
            underground = true;
            yield return new WaitForSeconds(Random.Range(1.0f,2.0f));
            moving = false;
            anim.SetTrigger("Dig");
            yield return new WaitForSeconds(2);
            this.transform.position = new Vector3(this.transform.position.x,-0.3f, this.transform.position.z);
            
            
            moving = true;
        }
        else
        {
            this.transform.position = new Vector3(this.transform.position.x, 2f, this.transform.position.z);
            anim.SetTrigger("Surface");
            yield return new WaitForSeconds(3);
            underground = false;
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
