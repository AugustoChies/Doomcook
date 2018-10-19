using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KitchenCell : MonoBehaviour {
    public Food placed;
    protected GameObject carryobj;
    public bool preparing;

    public void SetFood(Food newfood)
    {
        preparing = true;
        placed = newfood;
    }

    public void ShowCarriedMesh(bool yes)
    {
        if (carryobj != null)
        {
            carryobj.SetActive(yes);
        }
    }

    public abstract Food TakeFood();
   

    public void SumFood(Food newfood)
    {
        Food summed = new Food(newfood.ingredients);

        for (int i=0; i< summed.ingredients.Count; i++)
        {
            placed.ingredients.Add(summed.ingredients[i]);
        }     
    }
}
