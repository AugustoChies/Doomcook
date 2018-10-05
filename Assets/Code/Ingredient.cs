using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour {
    public IngredientType type;
    public Preparation preparation = Preparation.unprepared;
    public CookPoint point = CookPoint.raw;
}
