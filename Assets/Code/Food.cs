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

    public bool Equals(Food f2)
    {
        if(this.ingredients.Count == f2.ingredients.Count)
        {
            bool equal = true;
            
            for (int i = 0; i < ingredients.Count; i++)
            {
                if(ingredients[i].type != f2.ingredients[i].type
                    || ingredients[i].preparation != f2.ingredients[i].preparation
                    || ingredients[i].point != f2.ingredients[i].point)
                {
                    equal = false;
                    break;
                }
                
            }

            return equal;
        }
        else
        {
            return false;
        }
    }   

}
