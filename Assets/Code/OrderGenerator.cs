
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Dificulty
{ easy,medium,hard};


public class OrderGenerator : MonoBehaviour {
    Food myOrder;
    public float remainingTime,time;
    public IngredientType[] possibleingredients;
    public Preparation[] possiblePreparations;
    public CookPoint[] possibleCooking;
    public Dificulty dificulty;
	// Use this for initialization
	void Start () {
        Generate();
	}
	
	// Update is called once per frame
	void Update () {
        remainingTime -= Time.deltaTime;
        if(remainingTime < 0)
        {
            Generate();
            remainingTime = time;              
        }
	}

    public void Generate()
    {
        int ingredientcount,randn;
        List<Ingredient> ingredientsgen = new List<Ingredient>();
        CookPoint cp = CookPoint.raw;
        switch (dificulty)
        {           
            case Dificulty.easy:
                ingredientcount = Random.Range(1, 3);

                randn = Random.Range(0, possibleCooking.Length);
                
                if (randn < 3)
                {
                    cp = CookPoint.raw;
                }
                else
                {
                    cp = possibleCooking[randn-2];
                }                

                for (int i = 0; i < ingredientcount; i++)
                {
                    randn = Random.Range(0, possibleingredients.Length);
                    IngredientType tp = possibleingredients[randn];
                    randn = Random.Range(0, possiblePreparations.Length);
                    Preparation pr = possiblePreparations[randn];

                    Ingredient ing = new Ingredient(tp, pr, cp);
                    ingredientsgen.Add(ing);
                }
                break;
            case Dificulty.medium:
                ingredientcount = Random.Range(1, 4);

                randn = Random.Range(0, possibleCooking.Length);
                CookPoint cp;
                if (randn < 3)
                {
                    cp = CookPoint.raw;
                }
                else
                {
                    cp = possibleCooking[randn - 2];
                }

                for (int i = 0; i < ingredientcount; i++)
                {
                    randn = Random.Range(0, possibleingredients.Length);
                    IngredientType tp = possibleingredients[randn];
                    randn = Random.Range(0, possiblePreparations.Length);
                    Preparation pr = possiblePreparations[randn];

                    Ingredient ing = new Ingredient(tp, pr, cp);
                    ingredientsgen.Add(ing);
                }
                break;
            case Dificulty.hard:
                break;
            default:
                break;
        }

        myOrder = new Food(ingredientsgen);
    }
}
