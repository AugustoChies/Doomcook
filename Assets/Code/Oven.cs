using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : KitchenCell{
    public float timer;
    public FloatReference prepTime;
    public GameObject meter,pointer;

    // Use this for initialization
    void Start () {
        timer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (preparing)
        {
            timer += Time.deltaTime;           

            pointer.transform.Rotate(0, 0, -360/prepTime.Value * 4  * Time.deltaTime);

            if(timer / prepTime > 1.0f)
            {
                meter.GetComponent<SpriteRenderer>().color = Color.black;
            }
            else if (timer / prepTime > 0.75f)
            {
                meter.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else if (timer / prepTime > 0.50f)
            {
                meter.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            else if (timer / prepTime > 0.25f)
            {
                meter.GetComponent<SpriteRenderer>().color = Color.green;
            }
            else
            {
                meter.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

    public void ShowMeter()
    {
        meter.SetActive(true);
        pointer.SetActive(true);
    }

    public override Food TakeFood()
    {
        for(int i = 0; i < placed.ingredients.Count; i++)
        {
            placed.ingredients[i].point = (CookPoint)((timer/prepTime) * 4);
            if(timer/prepTime * 4 > 4)
            {
                placed.ingredients[i].point = CookPoint.burned;
            }
        }
        
        preparing = false;
        timer = 0;
        meter.SetActive(false);
        pointer.SetActive(false);
        Food returnedfood = new Food(placed.ingredients);
        placed.ingredients = new List<Ingredient>();

        return returnedfood;
    }
}
