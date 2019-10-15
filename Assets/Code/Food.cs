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

    public Food()
    {
        ingredients = new List<Ingredient>();        
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

        if (this.ingredients.Count == f2.ingredients.Count)
        {
            Food token1 = new Food(this.ingredients);
            Food token2 = new Food(f2.ingredients);
            bool equal = false;
            short equalities = (short)this.ingredients.Count;

            for (int i = 0; i < token1.ingredients.Count; i++)
            {
                for (int k = 0; k < token2.ingredients.Count; k++)
                {
                    if (token1.ingredients[i].type == token2.ingredients[k].type
                        && token1.ingredients[i].preparation == token2.ingredients[k].preparation
                        && token1.ingredients[i].point == token2.ingredients[k].point)
                    {
                        equalities--;
                        token2.ingredients.RemoveAt(k);
                        break;
                    }
                }
                
            }
            if(equalities == 0)
            {
                equal = true;
            }
            
            return equal;
        }
        else
        {
            return false;
        }
    }   

}
