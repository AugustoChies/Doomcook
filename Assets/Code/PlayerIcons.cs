using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIcons : MonoBehaviour {
    public IngredientIconMap iic;
    public IngredientPrepMap pic;
    public IngredientCookMap cic;
    public GameObject ing1, ing2, ing3, ing4, ing5, ing6, ing7, ing8, ing9;
    public Transform iconmaster;
    // Use this for initialization
    void Awake () {
        iic.Init();
        pic.Init();
        cic.Init();
        iconmaster = transform.Find("Icons");
    }

    void Start()
    {          
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
    void Update () {
        Vector3 oldt = iconmaster.eulerAngles;
        iconmaster.rotation = Quaternion.Euler(oldt.x, oldt.y, oldt.z);
	}

    public void ShowIcons(bool yes, Food placed)
    {
        if (ing1 != null && placed.ingredients.Count > 0)
        {
            ing1.GetComponent<SpriteRenderer>().sprite = iic.pairs[placed.ingredients[0].type];
            ing1.SetActive(yes);
            if (placed.ingredients[0].IsPrepared())
            {
                ing4.GetComponent<SpriteRenderer>().sprite = pic.pairs[placed.ingredients[0].preparation];
                ing4.SetActive(yes);
            }
            else
                ing4.SetActive(false);

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
            if (placed.ingredients[1].IsPrepared())
            {
                ing5.GetComponent<SpriteRenderer>().sprite = pic.pairs[placed.ingredients[1].preparation];
                ing5.SetActive(yes);
            }
            else
                ing5.SetActive(false);

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

            if (placed.ingredients[2].IsPrepared())
            {
                ing6.GetComponent<SpriteRenderer>().sprite = pic.pairs[placed.ingredients[2].preparation];
                ing6.SetActive(yes);
            }
            else
                ing6.SetActive(false);

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
