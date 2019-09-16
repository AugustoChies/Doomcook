using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour {
    public float speed, power, attackspeed;
    public Food order;
    public GameObject iconMaster,myTable;
    public MonsterPrefList myList;

    public IngredientIconMap iic;
    public IngredientPrepMap pic;
    public IngredientCookMap cic;
    public FloatVariable life;

    protected float acounter = 0;
    public LanesMonsterList lanelist;
    public int myLane;

    [HideInInspector]
    public bool atTable = false;
    public bool moving = true;    
    public bool barred = false;
    protected Obstacle targetedObstacle;
	// Use this for initialization
	void Start () {        
        ShowCarriedMesh();        
    }

    public void SetFood(int index)
    {
        order = new Food(myList.dishes[index].ingredients);
    }

    public void ShowCarriedMesh()
    {       
        
        GameObject ing1, ing2, ing3, ing4, ing5, ing6, ing7, ing8, ing9;
        ing1 = iconMaster.transform.Find("Ing1").gameObject;
        ing2 = iconMaster.transform.Find("Ing2").gameObject;
        ing3 = iconMaster.transform.Find("Ing3").gameObject;
        ing4 = iconMaster.transform.Find("Ing4").gameObject;
        ing5 = iconMaster.transform.Find("Ing5").gameObject;
        ing6 = iconMaster.transform.Find("Ing6").gameObject;
        ing7 = iconMaster.transform.Find("Ing7").gameObject;
        ing8 = iconMaster.transform.Find("Ing8").gameObject;
        ing9 = iconMaster.transform.Find("Ing9").gameObject;

        ing1.SetActive(false);
        ing2.SetActive(false);
        ing3.SetActive(false);
        ing4.SetActive(false);
        ing5.SetActive(false);
        ing6.SetActive(false);
        ing7.SetActive(false);
        ing8.SetActive(false);
        ing9.SetActive(false);

        if (order.ingredients.Count > 0)
        {
            ing1.SetActive(true);
            ing1.GetComponent<SpriteRenderer>().sprite = iic.pairs[order.ingredients[0].type];
            if (order.ingredients[0].IsPrepared())
            {
                ing4.GetComponent<SpriteRenderer>().sprite = pic.pairs[order.ingredients[0].preparation];
                ing4.SetActive(true);
            }

            if (order.ingredients[0].IsCooked())
            {
                ing7.GetComponent<SpriteRenderer>().sprite = cic.pairs[order.ingredients[0].point];
                ing7.SetActive(true);
            }
        }
        if (order.ingredients.Count > 1)
        {
            ing2.SetActive(true);
            ing2.GetComponent<SpriteRenderer>().sprite = iic.pairs[order.ingredients[1].type];
            if (order.ingredients[1].IsPrepared())
            {
                ing5.GetComponent<SpriteRenderer>().sprite = pic.pairs[order.ingredients[1].preparation];
                ing5.SetActive(true);
            }

            if (order.ingredients[1].IsCooked())
            {
                ing8.GetComponent<SpriteRenderer>().sprite = cic.pairs[order.ingredients[1].point];
                ing8.SetActive(true);
            }
        }
        if (order.ingredients.Count > 2)
        {
            ing3.SetActive(true);
            ing3.GetComponent<SpriteRenderer>().sprite = iic.pairs[order.ingredients[2].type];
            if (order.ingredients[2].IsPrepared())
            {
                ing6.GetComponent<SpriteRenderer>().sprite = pic.pairs[order.ingredients[2].preparation];
                ing6.SetActive(true);
            }

            if (order.ingredients[2].IsCooked())
            {
                ing9.GetComponent<SpriteRenderer>().sprite = cic.pairs[order.ingredients[2].point];
                ing9.SetActive(true);
            }
        } 
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Table")
        {
            myTable = other.gameObject;
            atTable = true;
            moving = false;
        }
        else if (other.GetComponent<Obstacle>())
        {
            barred = true;
            moving = false;
            targetedObstacle = other.GetComponent<Obstacle>();
            targetedObstacle.barredMons.Add(this);
        }
    }

    public abstract void Attack();
    public abstract void AttackObstacle();

    IEnumerator Sink()
    {
        switch (myLane)
        {
            case 1:
                lanelist.lane1.Remove(this.gameObject);
                break;
            case 2:
                lanelist.lane2.Remove(this.gameObject);
                break;
            case 3:
                lanelist.lane3.Remove(this.gameObject);
                break;
            default:
                break;
        }
        for (float i = 0; i < 3; i += Time.deltaTime)
        {
            this.transform.position -= transform.up * 2 * Time.deltaTime;
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
