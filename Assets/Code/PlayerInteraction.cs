using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    public KeycodesReference controls;
    public BoolReference carrying;

    public float raycastLenght = 1;

    // Use this for initialization
    void Start () {
		
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
                        //hitcell.GetComponent<KitchenCell>().AlterFood();
                        if(carrying)
                        {
                            
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
