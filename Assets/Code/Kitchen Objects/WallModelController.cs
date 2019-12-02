using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallModelController : MonoBehaviour
{
    public GameState gs;
    public UpgradesStatus upgrades;
    public GameObject wall, strong, ultra;

    private void Update()
    {
        if(gs.upgrading)
        {
            wall.SetActive(false);
            strong.SetActive(false);
            ultra.SetActive(false);
            switch (upgrades.wallUpgrade)
            {
                case WallUpgrade.standart:
                    wall.SetActive(true);
                    break;
                case WallUpgrade.great:
                    strong.SetActive(true);
                    break;
                case WallUpgrade.greater:
                    ultra.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }
}
