using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zomboid : Monster {


    public override void Attack()
    {
        life.Value -= power;
    }

    public override void AttackObstacle()
    {
        targetedObstacle.life -= power;
    }
}
