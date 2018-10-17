using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : KitchenCell {
    public IngredientType myIngredient;
    public Preparation myPreparation;
    public CookPoint myPoint;
    public override void AlterFood()
    {
        
    }
    // Use this for initialization
    void Start () {
        Ingredient ing = new Ingredient(myIngredient,myPreparation,myPoint);
        placed = new Food(ing);        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
