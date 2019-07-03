using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptor : KitchenCell {
    public OrderGenerator og;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override Food TakeFood()
    {
        //nada
        return null;
    }

    public override void SumFood(Food newfood)
    {
        placed = new Food(newfood.ingredients);

        if(placed.Equals(og.myOrder))
        {           
            this.GetComponent<AudioSource>().Play();
            og.Generate();
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
