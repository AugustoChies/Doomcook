using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IngredientCookMap : ScriptableObject
{
    public Dictionary<CookPoint, Sprite> pairs = new Dictionary<CookPoint, Sprite>();
    public List<CookPoint> preparations;
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
