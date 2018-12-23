using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    public KeycodesReference controls;
    public bool carrying;
    public Food carried;
    public ModelReferenceList modelReferences;
    GameObject carryobj;
    public float raycastLenght = 1;

    // Use this for initialization
    void Start () {
        carryobj = transform.Find("CarriedFood").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(controls.interact))
        {            
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastLenght))
            {               
                GameObject hitcell = hit.transform.gameObject;
                if(hitcell.GetComponent<KitchenCell>())
                {
                    bool done = true;
                    if (carrying)
                    {
                        if (!hitcell.GetComponent<Dispenser>())
                        {
                            
                            if (hitcell.GetComponent<Counter>())
                            {                               
                                if (hitcell.GetComponent<KitchenCell>().placed.ingredients.Count + carried.ingredients.Count < 4)
                                { 
                                    if (hitcell.GetComponent<KitchenCell>().placed.ingredients.Count > 0)
                                    {
                                        for (int i = 0; i < carried.ingredients.Count; i++)
                                        {
                                            if (!carried.ingredients[i].IsPrepared())
                                            {
                                                done = false;
                                                break;
                                            }
                                        }
                                        if (!hitcell.GetComponent<KitchenCell>().placed.ingredients[0].IsPrepared())
                                        {
                                            done = false;
                                        }
                                    }                                                          
                                }
                                else
                                {
                                    done = false;
                                }
                            }
                            else if(hitcell.GetComponent<Preparer>() )
                            {
                                if(carried.ingredients.Count > 1 || carried.ingredients[0].IsPrepared() || !hitcell.GetComponent<Preparer>().CheckCompatibility(carried))
                                {
                                    done = false;
                                }
                            }
                            else if (hitcell.GetComponent<Oven>())
                            {
                                if (!carried.ingredients[0].IsPrepared())
                                {
                                    done = false;
                                }
                                for (int i = 0; i < carried.ingredients.Count; i++)
                                {
                                    if (carried.ingredients[i].IsCooked())
                                    {
                                        done = false;
                                        break;
                                    }
                                }
                            }

                            if (done)
                            {
                                if (hitcell.GetComponent<Preparer>() || hitcell.GetComponent<Oven>())
                                {
                                    hitcell.GetComponent<KitchenCell>().preparing = true;
                                    if(hitcell.GetComponent<Oven>())
                                    {
                                        hitcell.GetComponent<Oven>().ShowMeter();
                                    }
                                    else
                                    {
                                        hitcell.GetComponent<Preparer>().ShowMeter();
                                    }

                                }
                                hitcell.GetComponent<KitchenCell>().SumFood(carried);
                                hitcell.GetComponent<KitchenCell>().ShowCarriedMesh(true);
                                carrying = false;
                                this.gameObject.GetComponent<PlayerIcons>().ShowIcons(false, carried);
                                carried.ingredients = new List<Ingredient>();
                                carryobj.SetActive(false);

                            }
                        }
                    }
                    else
                    {
                        if (hitcell.GetComponent<KitchenCell>().placed.ingredients.Count > 0)
                        {
                            if (hitcell.GetComponent<Preparer>() && hitcell.GetComponent<Preparer>().preparing)
                            {
                                done = false;
                            }
                            if(done)
                            {
                                hitcell.GetComponent<KitchenCell>().ShowCarriedMesh(false);
                                carried = hitcell.GetComponent<KitchenCell>().TakeFood();
                                carrying = true;
                                for(int i=0;i < modelReferences.fms.Count;i++)
                                {
                                    if(modelReferences.fms[i].Check(carried))
                                    {                                        
                                        carryobj.GetComponent<MeshFilter>().mesh = modelReferences.fms[i].GetMesh(carried);
                                        break;
                                    }
                                }
                                carryobj.SetActive(true);
                                this.gameObject.GetComponent<PlayerIcons>().ShowIcons(true, carried);
                            }
                        }
                    }

                }
            }    
                        
        }
	}


#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * raycastLenght);
    }
# endif 
}
