
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Dificulty
{ easy,medium,hard};


public class OrderGenerator : MonoBehaviour {
    public Food myOrder;
    public float remainingTime,time;
    public IngredientType[] possibleingredients;
    public Preparation[] possiblePreparations;
    public CookPoint[] possibleCooking;
    public Dificulty dificulty;

    public IngredientIconMap iic;
    public IngredientPrepMap pic;
    public IngredientCookMap cic;
    protected GameObject ing1, ing2, ing3, ing4, ing5, ing6, ing7, ing8, ing9, fillbar;
    public Transform iconmaster;
    // Use this for initialization
    void Start () {
        ing1 = iconmaster.Find("Ing1").gameObject;
        ing2 = iconmaster.Find("Ing2").gameObject;
        ing3 = iconmaster.Find("Ing3").gameObject;
        ing4 = iconmaster.Find("Ing4").gameObject;
        ing5 = iconmaster.Find("Ing5").gameObject;
        ing6 = iconmaster.Find("Ing6").gameObject;
        ing7 = iconmaster.Find("Ing7").gameObject;
        ing8 = iconmaster.Find("Ing8").gameObject;
        ing9 = iconmaster.Find("Ing9").gameObject;
        fillbar = iconmaster.Find("FillBar").gameObject;

        Generate();
	}
	
	// Update is called once per frame
	void Update () {
        remainingTime -= Time.deltaTime;
        if(remainingTime < 0)
        {
            Generate();                         
        }

        fillbar.GetComponent<Image>().fillAmount = remainingTime / time;
        fillbar.GetComponent<Image>().color = Color.Lerp(Color.red, Color.green, remainingTime / time);
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
                
                if (randn < 2)
                {
                    cp = CookPoint.raw;
                }
                else
                {
                    cp = possibleCooking[randn - 1];
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
                ingredientcount = Random.Range(2, 4);                

                for (int i = 0; i < ingredientcount; i++)
                {
                    randn = Random.Range(0, possibleingredients.Length);
                    IngredientType tp = possibleingredients[randn];
                    randn = Random.Range(0, possiblePreparations.Length);
                    Preparation pr = possiblePreparations[randn];
                    randn = Random.Range(0, possibleCooking.Length);
                    cp = possibleCooking[randn];

                    Ingredient ing = new Ingredient(tp, pr, cp);
                    ingredientsgen.Add(ing);
                }
                break;
            default:
                break;
        }

        if(myOrder != null)
            ShowIcons(false, myOrder);
        myOrder = new Food(ingredientsgen);
        ShowIcons(true,myOrder);
        remainingTime = time;
    }

    public void ShowIcons(bool yes, Food placed)
    {
        fillbar.SetActive(yes);
        if (ing1 != null && placed.ingredients.Count > 0)
        {
            ing1.GetComponent<Image>().sprite = iic.pairs[placed.ingredients[0].type];
            ing1.SetActive(yes);
            if (placed.ingredients[0].IsPrepared())
            {
                ing4.GetComponent<Image>().sprite = pic.pairs[placed.ingredients[0].preparation];
                ing4.SetActive(yes);
            }
            else
                ing4.SetActive(false);

            if (placed.ingredients[0].IsCooked())
            {
                ing7.GetComponent<Image>().sprite = cic.pairs[placed.ingredients[0].point];
                ing7.SetActive(yes);
            }
            else
                ing7.SetActive(false);
        }
        if (ing2 != null && placed.ingredients.Count > 1)
        {
            ing2.GetComponent<Image>().sprite = iic.pairs[placed.ingredients[1].type];
            ing2.SetActive(yes);
            if (placed.ingredients[1].IsPrepared())
            {
                ing5.GetComponent<Image>().sprite = pic.pairs[placed.ingredients[1].preparation];
                ing5.SetActive(yes);
            }
            else
                ing5.SetActive(false);

            if (placed.ingredients[1].IsCooked())
            {
                ing8.GetComponent<Image>().sprite = cic.pairs[placed.ingredients[1].point];
                ing8.SetActive(yes);
            }
            else
                ing8.SetActive(false);
        }
        if (ing3 != null && placed.ingredients.Count > 2)
        {
            ing3.GetComponent<Image>().sprite = iic.pairs[placed.ingredients[2].type];
            ing3.SetActive(yes);

            if (placed.ingredients[2].IsPrepared())
            {
                ing6.GetComponent<Image>().sprite = pic.pairs[placed.ingredients[2].preparation];
                ing6.SetActive(yes);
            }
            else
                ing6.SetActive(false);

            if (placed.ingredients[2].IsCooked())
            {
                ing9.GetComponent<Image>().sprite = cic.pairs[placed.ingredients[2].point];
                ing9.SetActive(yes);
            }
            else
                ing9.SetActive(false);
        }
    }
}
