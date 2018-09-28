using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KitchenCell : MonoBehaviour {
    public GameObject interactionzone;
    public Food placed;

    public abstract void AlterFood();
}
