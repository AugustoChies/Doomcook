using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlazeSprite : Monster
{
    public ParticleSystem fire;

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
        fire.Play();
        source.clip = attack;
        source.Play();
        yield return new WaitForSeconds(1.0f);
        fire.Stop();
        life.Value -= power;
        
        for (int i = 0; i < myTable.GetComponent<Table>().placed.Count; i++)
        {
            Food newBurned = new Food(myTable.GetComponent<Table>().placed[i].ingredients);

            if (newBurned.ingredients.Count > 0)
            {
                newBurned.ingredients[0].point = CookPoint.burned;
            }
            if (newBurned.ingredients.Count > 1)
            {
                newBurned.ingredients[1].point = CookPoint.burned;
            }
            if (newBurned.ingredients.Count > 2)
            {
                newBurned.ingredients[2].point = CookPoint.burned;
            }

            myTable.GetComponent<Table>().placed[i] = new Food(newBurned.ingredients);
        }

        myTable.GetComponent<Table>().ShowCarriedMesh();
    }

    IEnumerator WaitAttackObstacle()
    {
        fire.Play();
        source.clip = attack;
        source.Play();
        yield return new WaitForSeconds(1.0f);
        fire.Stop();
        targetedObstacle.life -= power;
    }
}
