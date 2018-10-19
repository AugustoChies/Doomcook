using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : KitchenCell {

    void Start()
    {
        carryobj = transform.Find("CarriedFood").gameObject;
    }    

    public override Food TakeFood()
    {
        Food returnedfood = new Food(placed.ingredients);

        placed.ingredients = new List<Ingredient>();
        return returnedfood;
    }

}
