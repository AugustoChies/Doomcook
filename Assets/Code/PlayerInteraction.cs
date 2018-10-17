using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    public KeycodesReference controls;
    public bool carrying;
    public Food carried;
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
                    if (carrying)
                    {
                        if (!hitcell.GetComponent<Dispenser>())
                        {                            
                            if (hitcell.GetComponent<KitchenCell>().placed.ingredients.Count < 3)
                            {                               
                                bool done = true;

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
                                }

                                if (done)
                                {
                                    hitcell.GetComponent<KitchenCell>().SumFood(carried);
                                    carrying = false;
                                    carried = null;
                                    carryobj.SetActive(false);
                                }
                            }                             
                        }
                    }
                    else
                    {
                        if (hitcell.GetComponent<KitchenCell>().placed.ingredients.Count > 0)
                        {                            
                            carried = hitcell.GetComponent<KitchenCell>().TakeFood();
                            carrying = true;
                            carryobj.SetActive(true);
                            if (!hitcell.GetComponent<Dispenser>())
                            {
                                hitcell.GetComponent<KitchenCell>().SetFood(null);
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
