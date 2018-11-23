using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SingleIngredientModels : ScriptableObject {
    public IngredientType type;

    public Mesh unprepared, chopped, mashed, grated;

    public Mesh GetMesh(Preparation prep)
    {
        switch (prep)
        {
            case Preparation.unprepared:
                return unprepared;                
            case Preparation.chopped:
                return chopped;                
            case Preparation.mashed:
                return mashed;
            case Preparation.grated:
                return grated;
            default:
                return null;               
        }
    }
}
