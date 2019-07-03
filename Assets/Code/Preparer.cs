using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preparer : KitchenCell {
    public PreparationEffect pe;
    public float timer;
    public FloatReference prepTime;
    public GameObject meter, pointer;

    // Use this for initialization
    void Start () {
        playerChar = GameObject.Find("Player");
        carryobj = transform.Find("CarriedFood").gameObject;
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(preparing)
        {            
            timer += Time.deltaTime;
            pointer.transform.Rotate(0, 0, -360 / prepTime.Value * Time.deltaTime);
            if (timer >= prepTime.Value)
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

    public void ShowMeter()
    {
        meter.SetActive(true);
        pointer.SetActive(true);
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
        meter.SetActive(false);
        pointer.SetActive(false);
        Food returnedfood = new Food(placed.ingredients);
        placed.ingredients = new List<Ingredient>();

        return returnedfood;
    }

    public override void SumFood(Food newfood)
    {
        preparing = true;
        ShowMeter();
        Food summed = new Food(newfood.ingredients);

        for (int i = 0; i < summed.ingredients.Count; i++)
        {
            placed.ingredients.Add(summed.ingredients[i]);
        }
    }

    public override bool CanbeTaken()
    {        
        return !preparing;
    }
    public override bool CanbePlaced()
    {
        if (playerChar.GetComponent<PlayerInteraction>().carried.ingredients.Count > 1 
            || playerChar.GetComponent<PlayerInteraction>().carried.ingredients[0].IsPrepared() 
            || !CheckCompatibility(playerChar.GetComponent<PlayerInteraction>().carried))
        {
            return false;
        }
        return true;
    }
}
