using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : KitchenCell {

    public override void AlterFood()
    {
        this.gameObject.GetComponent<MeshRenderer>().material.color *= -1;
    }

}
