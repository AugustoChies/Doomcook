using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayOrderChanger : MonoBehaviour
{
    GameObject iconmaster;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.Find("Ing1").GetComponent<SpriteRenderer>().sortingOrder+= (int)this.transform.position.z * -1 * 3;
        this.transform.Find("Ing2").GetComponent<SpriteRenderer>().sortingOrder+= (int)this.transform.position.z * -1 * 3;
        this.transform.Find("Ing3").GetComponent<SpriteRenderer>().sortingOrder+= (int)this.transform.position.z * -1 * 3;
        this.transform.Find("Ing4").GetComponent<SpriteRenderer>().sortingOrder+= (int)this.transform.position.z * -1 * 3;
        this.transform.Find("Ing5").GetComponent<SpriteRenderer>().sortingOrder+= (int)this.transform.position.z * -1 * 3;
        this.transform.Find("Ing6").GetComponent<SpriteRenderer>().sortingOrder+= (int)this.transform.position.z * -1 * 3;
        this.transform.Find("Ing7").GetComponent<SpriteRenderer>().sortingOrder+= (int)this.transform.position.z * -1 * 3;
        this.transform.Find("Ing8").GetComponent<SpriteRenderer>().sortingOrder+= (int)this.transform.position.z * -1 * 3;
        this.transform.Find("Ing9").GetComponent<SpriteRenderer>().sortingOrder += (int)this.transform.position.z * -1* 3;
        this.transform.Find("Bubble").GetComponent<SpriteRenderer>().sortingOrder += (int)this.transform.position.z * -1 * 3;
    }


}
