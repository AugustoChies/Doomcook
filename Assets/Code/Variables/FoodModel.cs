﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FoodModel : ScriptableObject {
    public SingleIngModelsList smlist;
    public Mesh myMesh;
    public int maxIngcount;
    public bool hasVegetable, hasMeat;
    public CookPoint highestPoint;
    
    //chech if food applies to criteria
    public bool Check(Food f)
    {
        if(maxIngcount == 0) //ingcount 0 is for the last model in list, the dubious food
        {
            return true;
        }
        if(maxIngcount < f.ingredients.Count)
        {
            Debug.Log("Failed at count");
            return false;
        }

        for (int i = 0; i < f.ingredients.Count; i++)
        {
            if (highestPoint < f.ingredients[i].point)
            {
                Debug.Log("Failed at point");
                return false;
            }
        }

        bool yes = false;

        for (int i = 0; i < f.ingredients.Count; i++)
        {
            if (hasVegetable)
            {
                if (f.ingredients[i].type.isVegetable)
                {
                    yes = true;
                    break;
                }
            }
            else
            {
                if (f.ingredients[i].type.isVegetable)
                {
                    Debug.Log("Failed at no veg");
                    return false;
                }
            }            
        }
        if(!yes)
        {
            Debug.Log("Failed at veg");
            return false;
        }

        yes = false;

        for (int i = 0; i < f.ingredients.Count; i++)
        {
            if (hasMeat)
            {
                if (f.ingredients[i].type.isMeat)
                {
                    yes = true;
                    break;
                }
            }
            else
            {
                yes = true;
                if (f.ingredients[i].type.isMeat)
                {
                    Debug.Log("Failed at no meat");
                    return false;
                }
            }
        }
        if (!yes)
        {
            Debug.Log("Failed at meat");
            return false;
        }
        

        return true;
    }

    public Mesh GetMesh(Food f)
    {
        if(maxIngcount == 1)
        {
            for (int i = 0; i < smlist.list.Count; i++)
            {
                if(smlist.list[i].type == f.ingredients[0].type)
                {
                    return smlist.list[i].GetMesh(f.ingredients[0].preparation);
                }
            }
            return null;
        }
        else
        {
            return myMesh;
        }
    }
}