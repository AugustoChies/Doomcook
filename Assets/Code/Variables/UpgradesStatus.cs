using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WallUpgrade
{
    standart,great,greater
};

public enum PrepUpgrade
{
    standart,minigame,auto
};

public enum OvenUpgrade
{
    standart,fast,unburning
};


[CreateAssetMenu]
public class UpgradesStatus : ScriptableObject
{
    public WallUpgrade wallUpgrade;
    public PrepUpgrade prepUpgrade;
    public OvenUpgrade ovenUpgrade;
    public int tableCount;
    public int snackCount;
    public List<bool> screens;

    public int money, stars;
}
