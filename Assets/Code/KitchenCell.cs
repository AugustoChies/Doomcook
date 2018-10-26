using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KitchenCell : MonoBehaviour {
    public Food placed;
    protected GameObject carryobj,ing1,ing2,ing3;
    public bool preparing;
    public IngredientIconMap iic;

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
        if (ing1 != null && placed.ingredients.Count > 0)
        {
            ing1.GetComponent<SpriteRenderer>().sprite = iic.pairs[placed.ingredients[0].type];
            ing1.SetActive(yes);
        }
        if (ing2 != null && placed.ingredients.Count > 1)
        {
            ing2.GetComponent<SpriteRenderer>().sprite = iic.pairs[placed.ingredients[1].type];
            ing2.SetActive(yes);
        }
        if (ing3!= null && placed.ingredients.Count > 2)
        {
            ing3.GetComponent<SpriteRenderer>().sprite = iic.pairs[placed.ingredients[2].type];
            ing3.SetActive(yes);
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
