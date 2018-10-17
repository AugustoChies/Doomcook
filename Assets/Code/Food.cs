using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Food{
    public List<Ingredient> ingredients;
    public Food(Ingredient initialingredient)
    {
        ingredients = new List<Ingredient>
        {
            initialingredient
        };
    }

    public void AddIngredient(Ingredient newi)
    {
        ingredients.Add(newi);
    }

}
