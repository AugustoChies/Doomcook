using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIcons : MonoBehaviour {
    public IngredientIconMap iic;
    public GameObject ing1, ing2, ing3;
    public Transform iconmaster;
    // Use this for initialization
    void Awake () {
        iic.Init();
        iconmaster = transform.Find("Icons");
    }

    void Start()
    {          
        ing1 = iconmaster.Find("Ing1").gameObject;
        ing2 = iconmaster.Find("Ing2").gameObject;
        ing3 = iconmaster.Find("Ing3").gameObject;
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
        }
        if (ing2 != null && placed.ingredients.Count > 1)
        {
            ing2.GetComponent<SpriteRenderer>().sprite = iic.pairs[placed.ingredients[1].type];
            ing2.SetActive(yes);
        }
        if (ing3 != null && placed.ingredients.Count > 2)
        {
            ing3.GetComponent<SpriteRenderer>().sprite = iic.pairs[placed.ingredients[2].type];
            ing3.SetActive(yes);
        }
    }
}
