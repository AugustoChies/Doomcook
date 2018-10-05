using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KitchenCell : MonoBehaviour {
    public GameObject interactionzone;
    public Food placed;

    public abstract void AlterFood();
    public void SetFood(Food newfood)
    {
        placed = newfood;
    }
    
    public  void SumFood(Food newfood)
    {

    }
}
