using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : KitchenCell {

    void Start()
    {
        playerChar = GameObject.Find("Player");
            
        carryobj = transform.Find("CarriedFood").gameObject;
        ing1 = transform.Find("Ing1").gameObject;
        ing2 = transform.Find("Ing2").gameObject;
        ing3 = transform.Find("Ing3").gameObject;
        ing4 = transform.Find("Ing4").gameObject;
        ing5 = transform.Find("Ing5").gameObject;
        ing6 = transform.Find("Ing6").gameObject;
        ing7 = transform.Find("Ing7").gameObject;
        ing8 = transform.Find("Ing8").gameObject;
        ing9 = transform.Find("Ing9").gameObject;
    }    

    public override Food TakeFood()
    {
        Food returnedfood = new Food(placed.ingredients);

        placed.ingredients = new List<Ingredient>();
        return returnedfood;
    }

    public override void SumFood(Food newfood)
    {
        Food summed = new Food(newfood.ingredients);

        for (int i = 0; i < summed.ingredients.Count; i++)
        {
            placed.ingredients.Add(summed.ingredients[i]);
        }
    }

    public override bool CanbeTaken()
    {        
        return true;
    }
    public override bool CanbePlaced()
    {
        if (placed.ingredients.Count + playerChar.GetComponent<PlayerInteraction>().carried.ingredients.Count < 4)
        {
            //if (placed.ingredients.Count > 0)
            //{
            //    for (int i = 0; i < playerChar.GetComponent<PlayerInteraction>().carried.ingredients.Count; i++)
            //    {
            //        if (!playerChar.GetComponent<PlayerInteraction>().carried.ingredients[i].IsPrepared())
            //        {
            //            return false;
            //        }
            //    }
            //    if (!placed.ingredients[0].IsPrepared())
            //    {
            //        return false;
            //    }
            //}
        }
        else
        {
            return false;
        }
        return true;
    }
}
