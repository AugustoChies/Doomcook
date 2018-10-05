using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    public KeycodesReference controls;
    public BoolReference carrying;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(controls.interact))
        {            
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {               
                GameObject hitcell = hit.transform.gameObject;
                if(hitcell.GetComponent<KitchenCell>())
                {
                    if (hitcell.GetComponent<KitchenCell>().interactionzone.GetComponent<PlayerSensor>().isinside)
                    {
                        if (carrying)
                        {

                        }
                    }
                }
            }    
                        
        }
	}
}
