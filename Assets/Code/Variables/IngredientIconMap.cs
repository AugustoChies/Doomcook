using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class IngredientIconMap : ScriptableObject {
    public Dictionary<IngredientType,Sprite> pairs = new Dictionary<IngredientType, Sprite>();
    public List<IngredientType> ingredients;
    public List<Sprite> icons;    

    public void Init()
    {
        pairs.Clear();
        for (int i = 0; i < ingredients.Count; i++)
        {            
            pairs.Add(ingredients[i], icons[i]);
        }       
        
    }
}
