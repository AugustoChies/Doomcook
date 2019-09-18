using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MindFlayer : Monster
{
    public Distortion distManager;
    
    public override void Attack()
    {
        life.Value -= power;
        distManager.Activate();
    }

    public override void AttackObstacle()
    {
        targetedObstacle.life -= power;
    }
}
