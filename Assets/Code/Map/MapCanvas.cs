using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MapCanvas : MonoBehaviour
{
    public Resources resources;
    public UpgradesStatus upgrades;
    public TextMeshProUGUI moneytxt, startxt;
    // Start is called before the first frame update
    void Start()
    {
        int total = 0;
        for (int i = 0; i < resources.starsPerStage.Count; i++)
        {
            total += resources.starsPerStage[i];
        }
        upgrades.stars = total;
        moneytxt.text = "" + upgrades.money;
        startxt.text = "" + upgrades.stars;

    }

    public void QuitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
