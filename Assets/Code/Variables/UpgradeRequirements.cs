using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeIDs
{
    strongwall,strongestwall,autoprep,miniprep,fastburn,noburn,
    table,snack,screen
};

[CreateAssetMenu]
public class UpgradeRequirements : ScriptableObject
{
    public UpgradesStatus upgrades;
    public List<UpgradeIDs> iDs;
    public List<int> stars;
    public List<int> money;

    public void CheckAvailability(int ID)
    {
        if(ID <= 5)
        {

        }
    }
}
