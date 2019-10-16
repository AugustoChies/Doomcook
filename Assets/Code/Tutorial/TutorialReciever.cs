using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialReciever : KitchenCell
{
    public OrderGenerator og;
    public AudioClip right, wrong;
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
            this.GetComponent<AudioSource>().clip = right;
            this.GetComponent<AudioSource>().Play();
            og.remainingTime = 0;
        }
        else
        {
            this.GetComponent<AudioSource>().clip = wrong;
            this.GetComponent<AudioSource>().Play();
        }
    }

    public override bool CanbeTaken()
    {
        return false;
    }
    public override bool CanbePlaced()
    {
        return true;
    }
}
