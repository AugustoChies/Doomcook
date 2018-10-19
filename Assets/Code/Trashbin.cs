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
}
