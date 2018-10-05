using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : KitchenCell {

    public override void AlterFood()
    {
        this.gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0);
    }   


}
