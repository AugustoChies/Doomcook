using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : KitchenCell{
    public float timer;
    public FloatReference prepTime;
    public GameObject meter,pointer;
    public GameState gs;
    public UpgradesStatus upgrades;
    public OvenUpgrade myupgrade;
    public float quickmultiplier, slowmultiplier;

    // Use this for initialization
    void Start () {
        playerChar = GameObject.Find("Player");
        timer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if(gs.upgrading)
        {
            myupgrade = upgrades.ovenUpgrade;
        }
        if (preparing)
        {
            switch (myupgrade)
            {
                case OvenUpgrade.standart:
                    timer += Time.deltaTime;
                    pointer.transform.localEulerAngles = Vector3.Lerp(new Vector3(60, 0, 89.9f), new Vector3(60, 0, -89.9f), timer / prepTime);
                    break;
                case OvenUpgrade.fast:
                    timer += Time.deltaTime;
                    pointer.transform.localEulerAngles = Vector3.Lerp(new Vector3(60, 0, 89.9f), new Vector3(60, 0, -89.9f), timer / prepTime * quickmultiplier);
                    break;
                case OvenUpgrade.unburning:
                    timer += Time.deltaTime;
                    pointer.transform.localEulerAngles = Vector3.Lerp(new Vector3(60, 0, 89.9f), new Vector3(60, 0, -89.9f), timer / prepTime * slowmultiplier);
                    break;
                default:
                    break;
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
        switch (myupgrade)
        {
            case OvenUpgrade.standart:
                for (int i = 0; i < placed.ingredients.Count; i++)
                {
                    placed.ingredients[i].point = (CookPoint)((timer / prepTime) * 4);
                    if (timer / prepTime * 4 > 4)
                    {
                        placed.ingredients[i].point = CookPoint.burned;
                    }
                }
                break;
            case OvenUpgrade.fast:
                for (int i = 0; i < placed.ingredients.Count; i++)
                {
                    placed.ingredients[i].point = (CookPoint)((timer / prepTime * quickmultiplier) * 4);
                    if (timer / prepTime * quickmultiplier * 4 > 4)
                    {
                        placed.ingredients[i].point = CookPoint.burned;
                    }
                }
                break;
            case OvenUpgrade.unburning:
                for (int i = 0; i < placed.ingredients.Count; i++)
                {
                    placed.ingredients[i].point = (CookPoint)((timer / prepTime * slowmultiplier) * 4);
                    if (timer / prepTime * slowmultiplier * 4 > 4)
                    {
                        placed.ingredients[i].point = CookPoint.welldone;
                    }
                }
                break;
            default:
                break;
        }
       
        
        preparing = false;
        timer = 0;
        pointer.transform.eulerAngles = new Vector3(60,0,0);
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
        return true;
    }
    public override bool CanbePlaced()
    {
        if (!playerChar.GetComponent<PlayerInteraction>().carried.ingredients[0].IsPrepared())
        {
            return false;
        }
        for (int i = 0; i < playerChar.GetComponent<PlayerInteraction>().carried.ingredients.Count; i++)
        {
            if (playerChar.GetComponent<PlayerInteraction>().carried.ingredients[i].IsCooked())
            {
                return false;               
            }
        }
        return true;
    }

}
