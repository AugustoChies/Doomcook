using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : KitchenCell {

    void Start()
    {
        if (!iic.woke)
            iic.Init();
        carryobj = transform.Find("CarriedFood").gameObject;
        ing1 = transform.Find("Ing1").gameObject;
        ing2 = transform.Find("Ing2").gameObject;
        ing3 = transform.Find("Ing3").gameObject;
    }    

    public override Food TakeFood()
    {
        Food returnedfood = new Food(placed.ingredients);

        placed.ingredients = new List<Ingredient>();
        return returnedfood;
    }

}
