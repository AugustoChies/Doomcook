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

    public GameState gs;
    // Use this for initialization
    void Start () {
        carryobj = transform.Find("CarriedFood").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(controls.interact) && !gs.minigame)
        {            
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastLenght))
            {               
                GameObject hitcell = hit.transform.gameObject;
                if(hitcell.GetComponent<KitchenCell>())
                {                    
                    if (carrying)
                    {                       
                        if (hitcell.GetComponent<KitchenCell>().CanbePlaced())
                        {                                
                            hitcell.GetComponent<KitchenCell>().SumFood(carried);
                            hitcell.GetComponent<KitchenCell>().ShowCarriedMesh(true);
                            carrying = false;
                            this.gameObject.GetComponent<PlayerIcons>().ShowIcons(false, carried);
                            carried.ingredients = new List<Ingredient>();
                            carryobj.SetActive(false);

                        }
                        
                    }
                    else
                    {
                        if (hitcell.GetComponent<KitchenCell>().placed.ingredients.Count > 0)
                        {                            
                            if(hitcell.GetComponent<KitchenCell>().CanbeTaken())
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
