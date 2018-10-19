using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : KitchenCell{
    public float timer;
    public FloatReference prepTime;

    // Use this for initialization
    void Start () {
        timer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (preparing)
        {
            timer += Time.deltaTime;
        }
    }

    public override Food TakeFood()
    {
        for(int i = 0; i < placed.ingredients.Count; i++)
        {
            placed.ingredients[i].point = (CookPoint)((timer/prepTime) * 4);
        }
        
        preparing = false;
        timer = 0;
        Food returnedfood = new Food(placed.ingredients);
        placed.ingredients = new List<Ingredient>();

        return returnedfood;
    }
}
