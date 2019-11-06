using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptor : KitchenCell {
    //public OrderGenerator og;
    public Table myTable;

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
        for (int i = 0; i < myTable.placed.Count; i++)
        {
            if (myTable.placed[i].ingredients.Count == 0)
            {
                myTable.SumFood(placed, i);
                break;
            }
        }
        myTable.ShowCarriedMesh();

        //if(placed.Equals(og.myOrder))
        //{           
        //    this.GetComponent<AudioSource>().Play();
        //    og.Generate();
        //}
                
    }

    public override bool CanbeTaken()
    {
        return false;
    }
    public override bool CanbePlaced()
    {
        bool free = false;
        for (int i = 0; i < myTable.placed.Count; i++)
        {
            if(myTable.placed[i].ingredients.Count == 0)
            {
                free = true;
                break;
            }
        }
        return free;
    }
}
