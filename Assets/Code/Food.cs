using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Food : MonoBehaviour {
    protected List<Ingredient> ingredients;
	

    public void AddIngredient(Ingredient newi)
    {
        ingredients.Add(newi);
    }

}
