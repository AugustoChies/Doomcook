using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KitchenCell : MonoBehaviour {
    public Food placed;

    public abstract void AlterFood();
    public void SetFood(Food newfood)
    {
        placed = newfood;
    }

    public Food TakeFood()
    {
        AlterFood();
        return placed;
    }

    public void SumFood(Food newfood)
    {     
        for (int i=0; i< newfood.ingredients.Count; i++)
        {
            placed.ingredients.Add(newfood.ingredients[i]);
        }     
    }
}
