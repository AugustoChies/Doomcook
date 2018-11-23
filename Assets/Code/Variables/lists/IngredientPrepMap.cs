using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IngredientPrepMap : ScriptableObject
{
    public Dictionary<Preparation, Sprite> pairs = new Dictionary<Preparation, Sprite>();
    public List<Preparation> preparations;
    public List<Sprite> icons;

    public void Init()
    {
        pairs.Clear();
        for (int i = 0; i < preparations.Count; i++)
        {
            pairs.Add(preparations[i], icons[i]);
        }

    }
}