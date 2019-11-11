using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    public IngredientIconMap iic;
    public IngredientPrepMap pic;
    public IngredientCookMap cic;
    private GameObject ing1, ing2, ing3, ing4, ing5, ing6, ing7, ing8, ing9;
    private Transform iconmaster;
    private Food mahfood;
    private GameObject mahmonsta;
    public int myLane;
    public LanesMonsterList lanelist;
    

    // Start is called before the first frame update
    void Awake()
    {
        iconmaster = transform.Find("Icons");
        ing1 = iconmaster.Find("Ing1").gameObject;
        ing2 = iconmaster.Find("Ing2").gameObject;
        ing3 = iconmaster.Find("Ing3").gameObject;
        ing4 = iconmaster.Find("Ing4").gameObject;
        ing5 = iconmaster.Find("Ing5").gameObject;
        ing6 = iconmaster.Find("Ing6").gameObject;
        ing7 = iconmaster.Find("Ing7").gameObject;
        ing8 = iconmaster.Find("Ing8").gameObject;
        ing9 = iconmaster.Find("Ing9").gameObject;
    }

    
    // Update is called once per frame
    void Update()
    {
       // if(!mahmonsta || !mahmonsta.GetComponent<Monster>().onlist)
       // {           
            if(lanelist.lanes[myLane - 1].Count > 0)
            {
                float closestDist = Vector3.Distance(lanelist.lanes[myLane - 1][0].transform.position, this.transform.position);
                int closestIndex = 0;
                for (int i = 0; i < lanelist.lanes[myLane - 1].Count; i++)
                {
                    if(Vector3.Distance(lanelist.lanes[myLane - 1][i].transform.position, this.transform.position) < closestDist)
                    {
                        closestDist = Vector3.Distance(lanelist.lanes[myLane - 1][i].transform.position, this.transform.position);
                        closestIndex = i;
                    }
                }

                mahmonsta = lanelist.lanes[myLane - 1][closestIndex];
                mahfood = mahmonsta.GetComponent<Monster>().order;
                ShowIcons(true, mahfood);
            } 
            else
            {
                ShowIcons(false, mahfood);
            }
        //}
    }

    public void ShowIcons(bool yes, Food placed)
    {
        
            ing1.SetActive(false);
            ing2.SetActive(false);
            ing3.SetActive(false);
            ing4.SetActive(false);
            ing5.SetActive(false);
            ing6.SetActive(false);
            ing7.SetActive(false);
            ing8.SetActive(false);
            ing9.SetActive(false);

        if (!yes)
        {
            return;
        }


        if (ing1 != null && placed.ingredients.Count > 0)
        {
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
    }
}
