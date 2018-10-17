using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ingredient{
    public IngredientType type;
    public Preparation preparation = Preparation.unprepared;
    public CookPoint point = CookPoint.raw;

    public Ingredient(IngredientType t,Preparation p,CookPoint cp)
    {
        type = t;
        preparation = p;
        point = cp;
    }

    public bool IsPrepared()
    {
        return (preparation != Preparation.unprepared);
    }
}
