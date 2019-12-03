﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MindFlayer : Monster
{
    public Distortion distManager;
    public ParticleSystem psi;

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
        psi.Play();
        yield return new WaitForSeconds(0.7f);
        psi.Stop();
        life.Value -= power;
        distManager.Activate();
    }

    IEnumerator WaitAttackObstacle()
    {
        psi.Play();
        yield return new WaitForSeconds(0.7f);
        psi.Stop();
        targetedObstacle.life -= power;
    }
}
