using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour {
    public List<Food> placed;
    protected List<GameObject> carryobjs;
    public ModelReferenceList modelReferences;
    public IngredientIconMap iic;
    public IngredientPrepMap pic;
    public IngredientCookMap cic;
    // Use this for initialization
    void Start () {
        carryobjs = new List<GameObject>();
        carryobjs.Add(transform.Find("CarriedFood").gameObject);
        carryobjs.Add(transform.Find("CarriedFood2").gameObject);        
        placed = new List<Food>();
        placed.Add(new Food());
        placed.Add(new Food());      
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void SumFood(Food newfood,int k)
    {
        Food summed = new Food(newfood.ingredients);

        for (int i = 0; i < summed.ingredients.Count; i++)
        {
            placed[k].ingredients.Add(summed.ingredients[i]);
        }
    }

    public void ShowCarriedMesh()
    {
        for (int k = 0; k < placed.Count; k++)
        {
            carryobjs[k].SetActive(false);
            if (placed[k].ingredients.Count > 0)
            {
                carryobjs[k].SetActive(true);
                for (int i = 0; i < modelReferences.fms.Count; i++)
                {
                    if (modelReferences.fms[i].Check(placed[k]))
                    {
                        carryobjs[k].GetComponent<MeshFilter>().mesh = modelReferences.fms[i].GetMesh(placed[k]);
                        break;
                    }
                }
                GameObject ing1, ing2, ing3, ing4, ing5, ing6, ing7, ing8, ing9;
                ing1 = carryobjs[k].transform.Find("Ing1").gameObject;
                ing2 = carryobjs[k].transform.Find("Ing2").gameObject;
                ing3 = carryobjs[k].transform.Find("Ing3").gameObject;
                ing4 = carryobjs[k].transform.Find("Ing4").gameObject;
                ing5 = carryobjs[k].transform.Find("Ing5").gameObject;
                ing6 = carryobjs[k].transform.Find("Ing6").gameObject;
                ing7 = carryobjs[k].transform.Find("Ing7").gameObject;
                ing8 = carryobjs[k].transform.Find("Ing8").gameObject;
                ing9 = carryobjs[k].transform.Find("Ing9").gameObject;

                ing1.SetActive(false);
                ing2.SetActive(false);
                ing3.SetActive(false);
                ing4.SetActive(false);
                ing5.SetActive(false);
                ing6.SetActive(false);
                ing7.SetActive(false);
                ing8.SetActive(false);
                ing9.SetActive(false);

                if (placed[k].ingredients.Count > 0)
                {
                    ing1.SetActive(true);
                    ing1.GetComponent<SpriteRenderer>().sprite = iic.pairs[placed[k].ingredients[0].type];
                    if (placed[k].ingredients[0].IsPrepared())
                    {
                        ing4.GetComponent<SpriteRenderer>().sprite = pic.pairs[placed[k].ingredients[0].preparation];
                        ing4.SetActive(true);
                    }                       

                    if (placed[k].ingredients[0].IsCooked())
                    {
                        ing7.GetComponent<SpriteRenderer>().sprite = cic.pairs[placed[k].ingredients[0].point];
                        ing7.SetActive(true);
                    }                       
                }
                if (placed[k].ingredients.Count > 1)
                {
                    ing2.SetActive(true);
                    ing2.GetComponent<SpriteRenderer>().sprite = iic.pairs[placed[k].ingredients[1].type];
                    if (placed[k].ingredients[1].IsPrepared())
                    {
                        ing5.GetComponent<SpriteRenderer>().sprite = pic.pairs[placed[k].ingredients[1].preparation];
                        ing5.SetActive(true);
                    }

                    if (placed[k].ingredients[1].IsCooked())
                    {
                        ing8.GetComponent<SpriteRenderer>().sprite = cic.pairs[placed[k].ingredients[1].point];
                        ing8.SetActive(true);
                    }
                }
                if (placed[k].ingredients.Count > 2)
                {
                    ing3.SetActive(true);
                    ing3.GetComponent<SpriteRenderer>().sprite = iic.pairs[placed[k].ingredients[2].type];
                    if (placed[k].ingredients[2].IsPrepared())
                    {
                        ing6.GetComponent<SpriteRenderer>().sprite = pic.pairs[placed[k].ingredients[2].preparation];
                        ing6.SetActive(true);
                    }

                    if (placed[k].ingredients[2].IsCooked())
                    {
                        ing9.GetComponent<SpriteRenderer>().sprite = cic.pairs[placed[k].ingredients[2].point];
                        ing9.SetActive(true);
                    }
                }

            }
            else
            {
                carryobjs[k].SetActive(false);
            }
        }  
    }

    public void DeleteFood(short index)
    {
        placed[index] = (new Food());
        ShowCarriedMesh();
    }
}
