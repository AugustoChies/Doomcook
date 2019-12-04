using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zomboid : Monster {


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
        source.clip = attack;
        source.Play();
        life.Value -= power;
    }

    IEnumerator WaitAttackObstacle()
    {
        yield return new WaitForSeconds(0.8f);
        source.clip = attack;
        source.Play();
        targetedObstacle.life -= power;
    }
}
