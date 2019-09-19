using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodClicking : MonoBehaviour
{
    public Table mytable;
    public short myIndex;
    void Start()
    {
        mytable = this.transform.parent.GetComponent<Table>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)){
            mytable.DeleteFood(myIndex);
        }
    }
}
