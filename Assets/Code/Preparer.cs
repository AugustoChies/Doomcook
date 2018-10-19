using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preparer : KitchenCell {
    public PreparationEffect pe;
    public float timer;
    public FloatReference prepTime;

	// Use this for initialization
	void Start () {
        carryobj = transform.Find("CarriedFood").gameObject;
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(preparing)
        {            
            timer += Time.deltaTime;
            if(timer >= prepTime.Value)
            {
                timer = 0;
                preparing = false;
                for (int i = 0; i < placed.ingredients.Count; i++)
                {
                    placed.ingredients[i].preparation = pe.myprep;
                }
            }
        }
	}

    public bool CheckCompatibility(Food food)
    {
        bool compatible = false;

        switch (pe.myprep)
        {            
            case Preparation.chopped:
                if(food.ingredients[0].type.IsChoppable)
                {
                    compatible = true;
                }
                break;
            case Preparation.mashed:
                if (food.ingredients[0].type.IsMashable)
                {
                    compatible = true;
                }
                break;
            case Preparation.grated:
                if (food.ingredients[0].type.IsGratable)
                {
                    compatible = true;
                }
                break;
            default:
                break;
        }

        return compatible;
    }

    public override Food TakeFood()
    {        
        Food returnedfood = new Food(placed.ingredients);
        placed.ingredients = new List<Ingredient>();

        return returnedfood;
    }
}
