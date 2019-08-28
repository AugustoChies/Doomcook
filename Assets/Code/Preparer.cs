using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preparer : KitchenCell {
    public FloatVariable preptime;
    public PreparationEffect pe;
    public GameObject meter, pointer;
    public MinigamesScript minigames;
    public GameState gs;

    private float localtimer;
    // Use this for initialization
    void Start () {
        playerChar = GameObject.Find("Player");
        minigames = GameObject.Find("OrderCanvas").GetComponent<MinigamesScript>();
        carryobj = transform.Find("CarriedFood").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(preparing)
        {            
            if (!gs.minigame)
            {                
                preparing = false;
                for (int i = 0; i < placed.ingredients.Count; i++)
                {
                    placed.ingredients[i].preparation = pe.myprep;
                }
                ShowCarriedMesh(true);
            }
            else
            {
                localtimer += Time.deltaTime;
                pointer.transform.Rotate(0, 0, -360 * Time.deltaTime / preptime.Value);
                if(localtimer >= preptime.Value)
                {
                    gs.minigame = false;
                    pointer.transform.eulerAngles = new Vector3(60,0,0);
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
        localtimer = 0;
        Food summed = new Food(newfood.ingredients);

        for (int i = 0; i < summed.ingredients.Count; i++)
        {
            placed.ingredients.Add(summed.ingredients[i]);
        }

        gs.minigame = true;

        //switch (pe.myprep)
        //{
        //    case Preparation.chopped:
        //        minigames.StartCutting(5);
        //        break;
        //    case Preparation.mashed:
        //        minigames.StartMashing(5);
        //        break;
        //    case Preparation.grated:
        //        minigames.StartGrating(5);
        //        break;
        //    default:
        //        break;
        //}
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
