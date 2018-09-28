using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    public KeycodesReference controls;
    public BoolReference carrying;
    public GameObject currentInteractionZone;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(controls.interact))
        {
            if(carrying)
            {

            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Interaction")
        {
            currentInteractionZone = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Interaction")
        {
            if(currentInteractionZone == other.gameObject)
            {
                currentInteractionZone = null;
            }
        }
    }
}
