using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MindFlayer : Monster
{
    public Distortion distManager;

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
        yield return new WaitForSeconds(0.7f);
        life.Value -= power;
        distManager.Activate();
    }

    IEnumerator WaitAttackObstacle()
    {
        yield return new WaitForSeconds(0.7f);
        targetedObstacle.life -= power;
    }
}
