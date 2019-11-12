using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KitchenCell : MonoBehaviour {
    public Food placed;
    protected GameObject carryobj,ing1,ing2,ing3,ing4,ing5,ing6,ing7,ing8,ing9,bubble;
    public bool preparing;
    public ModelReferenceList modelReferences;
    public IngredientIconMap iic;
    public IngredientPrepMap pic;
    public IngredientCookMap cic;
    public GameObject playerChar;

    

    public void ShowCarriedMesh(bool yes)
    {
        if (ing1 != null && placed.ingredients.Count > 0)
        {
            bubble.SetActive(yes);

            ing1.GetComponent<SpriteRenderer>().sprite = iic.pairs[placed.ingredients[0].type];
            ing1.SetActive(yes);

            ing4.GetComponent<SpriteRenderer>().sprite = pic.pairs[placed.ingredients[0].preparation];
            ing4.SetActive(yes);


            if (placed.ingredients[0].IsCooked())
            {
                ing7.GetComponent<SpriteRenderer>().sprite = cic.pairs[placed.ingredients[0].point];
                ing7.SetActive(yes);
            }
            else
                ing7.SetActive(false);
        }
        if (ing2 != null && placed.ingredients.Count > 1)
        {
            ing2.GetComponent<SpriteRenderer>().sprite = iic.pairs[placed.ingredients[1].type];
            ing2.SetActive(yes);

            ing5.GetComponent<SpriteRenderer>().sprite = pic.pairs[placed.ingredients[1].preparation];
            ing5.SetActive(yes);


            if (placed.ingredients[1].IsCooked())
            {
                ing8.GetComponent<SpriteRenderer>().sprite = cic.pairs[placed.ingredients[1].point];
                ing8.SetActive(yes);
            }
            else
                ing8.SetActive(false);
        }
        if (ing3 != null && placed.ingredients.Count > 2)
        {
            ing3.GetComponent<SpriteRenderer>().sprite = iic.pairs[placed.ingredients[2].type];
            ing3.SetActive(yes);


            ing6.GetComponent<SpriteRenderer>().sprite = pic.pairs[placed.ingredients[2].preparation];
            ing6.SetActive(yes);


            if (placed.ingredients[2].IsCooked())
            {
                ing9.GetComponent<SpriteRenderer>().sprite = cic.pairs[placed.ingredients[2].point];
                ing9.SetActive(yes);
            }
            else
                ing9.SetActive(false);
        }
        StartCoroutine(ShowStuff(yes));
    }

    public abstract Food TakeFood();


    public abstract void SumFood(Food newfood);

    public abstract bool CanbeTaken();
    public abstract bool CanbePlaced();

    IEnumerator ShowStuff(bool yes)
    {
        if (!yes)
        {
            yield return new WaitForSeconds(0.15f);
        }
        

        if (carryobj != null)
        {
            carryobj.SetActive(yes);
            if (yes)
            {
                for (int i = 0; i < modelReferences.fms.Count; i++)
                {
                    if (modelReferences.fms[i].Check(placed))
                    {
                        carryobj.GetComponent<MeshFilter>().mesh = modelReferences.fms[i].GetMesh(placed);
                        break;
                    }
                }
            }
        }
        
    }
}
