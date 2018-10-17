using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensor : MonoBehaviour {
    public bool isinside;
    
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            isinside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isinside = false;
        }
    }
}
