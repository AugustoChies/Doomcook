using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    public KeycodesReference controls;
    public bool carrying,working;
    public Food carried;
    public ModelReferenceList modelReferences;
    public GameObject carryobj;
    public float raycastLenght = 1;
    public Animator anim;
    public GameState gs;
    // Use this for initialization
    void Start () {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(controls.interact) && !gs.minigame && !gs.wide && !gs.upgrading && !gs.tutorial && !gs.end)
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

                            if(gs.minigame)
                            {
                                anim.SetTrigger("StartPrep");
                                anim.SetBool("Working", true);
                                working = true;
                            }

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
                                StartCoroutine(ShowFood());
                                this.gameObject.GetComponent<PlayerIcons>().ShowIcons(true, carried);
                            }
                        }
                    }

                }
            }    
                        
        }
        if (Input.GetKeyDown(controls.alternateminigame) && !gs.minigame && !gs.wide && !gs.upgrading && !gs.tutorial && !gs.end)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastLenght))
            {
                GameObject hitcell = hit.transform.gameObject;
                if (hitcell.GetComponent<Oven>() && hitcell.GetComponent<Oven>().myupgrade == OvenUpgrade.unburning)
                {
                    if(!carrying)
                    {
                        if (hitcell.GetComponent<KitchenCell>().placed.ingredients.Count > 0)
                        {                            
                            hitcell.GetComponent<KitchenCell>().ShowCarriedMesh(false);
                            carried = hitcell.GetComponent<Oven>().TakeAlternateFood();
                            carrying = true;
                            for (int i = 0; i < modelReferences.fms.Count; i++)
                            {
                                if (modelReferences.fms[i].Check(carried))
                                {
                                    carryobj.GetComponent<MeshFilter>().mesh = modelReferences.fms[i].GetMesh(carried);
                                    break;
                                }
                            }
                            StartCoroutine(ShowFood());
                            this.gameObject.GetComponent<PlayerIcons>().ShowIcons(true, carried);
                        }
                    }
                }
            }
        }

        if (carrying)
        {
            anim.SetBool("Carrying", true);
        }
        else
        {
            anim.SetBool("Carrying", false);
        }

        if(working)
        {
            if(!gs.minigame)
            {
                anim.SetBool("Working", false);
                working = false;
            }
        }
    }

    IEnumerator ShowFood()
    {
        yield return new WaitForSeconds(0.15f);
        carryobj.SetActive(true);

    }


#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * raycastLenght);
    }
# endif 
}
