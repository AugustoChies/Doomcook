using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashbin : KitchenCell {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(placed.ingredients.Count > 0)
        {
            placed.ingredients.Clear();
        }
	}

    public override Food TakeFood()
    {
        //nada
        return null;
    }

    public override void SumFood(Food newfood)
    {
        Food summed = new Food(newfood.ingredients);

        for (int i = 0; i < summed.ingredients.Count; i++)
        {
            placed.ingredients.Add(summed.ingredients[i]);
        }
    }

    public override bool CanbeTaken()
    {
        return true;
    }
    public override bool CanbePlaced()
    {
        return true;
    }
}
