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
    public float snackEatingTime;
    public float snackpersonaltime;

    protected float acounter = 0;
    public LanesMonsterList lanelist;
    public int myLane;
    public Animator anim;

    [HideInInspector]
    public bool atTable = false;
    public bool moving = true;    
    public bool barred = false;

    public bool snacking = false;
    public bool eatingSnack = false;
    public bool ateSnack = false;
    public float snackXPos;
    public bool up;
    public float originalZ;
    protected Snacktable snacktable;

    public bool onlist;
    protected Obstacle targetedObstacle;

    [SerializeField]
    protected Vector3 angles;
    protected Quaternion rotation;
    // Use this for initialization
    void Start()
    {
        ShowCarriedMesh();
        rotation = Quaternion.Euler(angles);

        originalZ = this.transform.position.z;
    }

    void Update()
    {
        anim.SetBool("Moving", false);
        anim.SetBool("Snacking", false);

        if (moving)
        {
            anim.SetBool("Moving", true);

            this.transform.position += transform.forward * speed * Time.deltaTime;
            if (ateSnack && this.transform.position.z > originalZ + 0.05f)
            {
                this.transform.position += transform.right * speed * Time.deltaTime;
            }
            else if (ateSnack && this.transform.position.z < originalZ - 0.05f)
            {
                this.transform.position += -transform.right * speed * Time.deltaTime;
            }

            if (snacking && this.transform.position.x >= snackXPos)
            {
                if (up)
                {
                    this.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, 180, 0);
                }
                snacking = false;
            }
        }
        else if (atTable)
        {
            bool eat = false;
            for (int i = 0; i < myTable.GetComponent<Table>().placed.Count; i++)
            {
                if (myTable.GetComponent<Table>().placed[i].Equals(order))
                {
                    eat = true;
                    atTable = false;
                    myTable.GetComponent<Table>().placed[i] = new Food();
                    order = new Food();
                    myTable.GetComponent<Table>().ShowCarriedMesh();
                    ShowCarriedMesh();
                    StartCoroutine("Sink");
                    break;
                }
            }
            if (!eat)
            {
                acounter += 1 * Time.deltaTime;
                if (acounter > attackspeed)
                {
                    acounter = 0;
                    anim.SetTrigger("Attack");
                    Attack();
                }
            }
        }
        else if (barred)
        {
            acounter += 1 * Time.deltaTime;
            if (acounter > attackspeed)
            {
                acounter = 0;
                anim.SetTrigger("Attack");
                AttackObstacle();
            }
        }
        else if (eatingSnack)
        {
            anim.SetBool("Snacking", true);
            snackpersonaltime += 1 * Time.deltaTime;
            if (snackpersonaltime >= snackEatingTime)
            {
                ateSnack = true;
                moving = true;
                snacktable.Eat();
                this.transform.eulerAngles = new Vector3(0, 90, 0);
            }
        }

        iconMaster.transform.rotation = rotation;

    }

    public void SetFood(int index)
    {
        order = new Food(myList.dishes[index].ingredients);
    }

    public void ShowCarriedMesh()
    {       
        
        GameObject ing1, ing2, ing3, ing4, ing5, ing6, ing7, ing8, ing9,bubble;
        ing1 = iconMaster.transform.Find("Ing1").gameObject;
        ing2 = iconMaster.transform.Find("Ing2").gameObject;
        ing3 = iconMaster.transform.Find("Ing3").gameObject;
        ing4 = iconMaster.transform.Find("Ing4").gameObject;
        ing5 = iconMaster.transform.Find("Ing5").gameObject;
        ing6 = iconMaster.transform.Find("Ing6").gameObject;
        ing7 = iconMaster.transform.Find("Ing7").gameObject;
        ing8 = iconMaster.transform.Find("Ing8").gameObject;
        ing9 = iconMaster.transform.Find("Ing9").gameObject;
        bubble = iconMaster.transform.Find("Bubble").gameObject;


        ing1.SetActive(false);
        ing2.SetActive(false);
        ing3.SetActive(false);
        ing4.SetActive(false);
        ing5.SetActive(false);
        ing6.SetActive(false);
        ing7.SetActive(false);
        ing8.SetActive(false);
        ing9.SetActive(false);
        bubble.SetActive(false);

        if (order.ingredients.Count > 0)
        {
            bubble.SetActive(true);
            ing1.SetActive(true);
            ing1.GetComponent<SpriteRenderer>().sprite = iic.pairs[order.ingredients[0].type];
            
                ing4.GetComponent<SpriteRenderer>().sprite = pic.pairs[order.ingredients[0].preparation];
                ing4.SetActive(true);
            

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
            
                ing5.GetComponent<SpriteRenderer>().sprite = pic.pairs[order.ingredients[1].preparation];
                ing5.SetActive(true);
            

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
            
                ing6.GetComponent<SpriteRenderer>().sprite = pic.pairs[order.ingredients[2].preparation];
                ing6.SetActive(true);
            

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
        else if(other.tag == "Snack")
        {
            if (!ateSnack && !snacking)
            {
                int availableSnacks = other.transform.parent.GetComponent<Snacktable>().availableSnacks;
                availableSnacks--;
                if(availableSnacks < 0) { availableSnacks = 0; }

                snackXPos = other.transform.parent.GetComponent<Snacktable>().snackmodels[7 - availableSnacks].transform.position.x;
                other.transform.parent.GetComponent<Snacktable>().availableSnacks--;                
                snacking = true;
                if (other.name == "Lower")
                {
                    up = true;
                }
                else if (other.name == "Upper")
                {
                    up = false;                    
                }
            }
            
        }
        else if (other.GetComponent<Obstacle>())
        {
            barred = true;
            moving = false;
            targetedObstacle = other.GetComponent<Obstacle>();
            targetedObstacle.barredMons.Add(this);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Snack")
        {
            moving = false;
            eatingSnack = true;
            anim.SetTrigger("Eat");
            snacktable = collision.transform.parent.gameObject.GetComponent<Snacktable>();
            snackEatingTime = snacktable.snackeatingtime;
            snackpersonaltime = 0;
        }
    }

    public abstract void Attack();
    public abstract void AttackObstacle();

    IEnumerator Sink()
    {
        anim.SetTrigger("Eat");
        lanelist.lanes[myLane - 1].Remove(this.gameObject);
        onlist = false;
        yield return new WaitForSeconds(1.5f);         
        for (float i = 0; i < 3; i += Time.deltaTime)
        {
            this.transform.position -= transform.up * 2 * Time.deltaTime;
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
