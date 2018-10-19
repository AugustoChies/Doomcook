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

    public Food(List<Ingredient> initialingredients)
    {
        ingredients = new List<Ingredient>();

        for(int i = 0; i < initialingredients.Count; i++)
        {
            ingredients.Add(initialingredients[i]);
        }
        
    }

    public void AddIngredient(Ingredient newi)
    {
        ingredients.Add(newi);
    }

}
