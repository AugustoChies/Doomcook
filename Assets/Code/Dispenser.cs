using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : KitchenCell {
    public IngredientType myIngredient;
    public Preparation myPreparation;
    public CookPoint myPoint;

    // Use this for initialization
    void Start () {
        Ingredient ing = new Ingredient(myIngredient,myPreparation,myPoint);
        placed = new Food(ing);        
    }

    public override Food TakeFood()
    {
        Food returnedfood = new Food(placed.ingredients);
        Ingredient ing = new Ingredient(myIngredient, myPreparation, myPoint);
        placed = new Food(ing);
        return returnedfood;
    }

    
}
