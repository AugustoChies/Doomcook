using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoseWinBehavior : MonoBehaviour
{
    public LifeControl life;
    public GameObject winCanvas;
    public GameObject loseCanvas;
    public LaneSpawner lane1, lane2, lane3;
    public LanesMonsterList monsterList;
    public GameState gs;
    public UpgradesStatus upgrades;
    private bool done;
    private TextMeshProUGUI reward;
    private GameObject[] stars;
    int obtainedmoney;
    int obtainedstars;
    public short stageIndex;
    public Resources resources;
    // Start is called before the first frame update
    void Start()
    {
        gs.end = false;
        stars = new GameObject[3];
        done = false;
        reward = winCanvas.transform.Find("RewardValue").GetComponent<TextMeshProUGUI>();
        stars[0] = winCanvas.transform.Find("Star1").gameObject;
        stars[1] = winCanvas.transform.Find("Star2").gameObject;
        stars[2] = winCanvas.transform.Find("Star3").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gs.upgrading && !done)
        {
            if (life.life.Value <= 0)
            {
                done = true;
                StartCoroutine(RiseLose());
                gs.end = true;
            }
            else if(lane1.monsters.Count == 0 && lane2.monsters.Count == 0 && lane3.monsters.Count == 0
                && monsterList.lanes[0].Count == 0 && monsterList.lanes[1].Count == 0 && monsterList.lanes[2].Count == 0)
            {
                done = true;
                gs.end = true;
                stars[0].SetActive(false);
                stars[1].SetActive(false);
                stars[2].SetActive(false);
                float targetLife = 0;
                switch (upgrades.wallUpgrade)
                {
                    case WallUpgrade.standart:
                        targetLife = life.normalLife;
                        break;
                    case WallUpgrade.great:
                        targetLife = life.life1;
                        break;
                    case WallUpgrade.greater:
                        targetLife = life.life2;
                        break;
                }

                if (life.life.Value/targetLife >= 1)
                {
                    obtainedstars = 3;
                }
                else if (life.life.Value / targetLife >= 0.5f)
                {
                    obtainedstars = 2;
                }
                else
                {
                    obtainedstars = 1;
                }
                obtainedmoney = obtainedstars * 200;
                if (resources.starsPerStage[stageIndex] < obtainedstars)
                {
                    resources.starsPerStage[stageIndex] = obtainedstars;
                }
                upgrades.money += obtainedmoney;

                StartCoroutine(RiseWin(obtainedmoney,obtainedstars));
            }
        }
    }

    public void ButtonMenu()
    {
        SceneManager.LoadScene("StageMap");
    }

    public void ButtonRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ButtonWinContinue()
    {
        int[] stars = new int[9];
        for (int i = 0; i < 9; i++)
        {
            PlayerPrefs.SetInt("Star" + i, resources.starsPerStage[i]);
        }

        int money = PlayerPrefs.GetInt("Money");
        int ovenstatus = PlayerPrefs.GetInt("Oven");
        int wallstatus = PlayerPrefs.GetInt("Wall");
        int prepstatus = PlayerPrefs.GetInt("Peparer");
        int tables = PlayerPrefs.GetInt("Tables");
        int snacks = PlayerPrefs.GetInt("Snacks");
        int screen0 = PlayerPrefs.GetInt("Screen0");
        int screen1 = PlayerPrefs.GetInt("Screen1");
        int screen2 = PlayerPrefs.GetInt("Screen2");

        upgrades.money = money;
        upgrades.ovenUpgrade = (OvenUpgrade)ovenstatus;
        upgrades.wallUpgrade = (WallUpgrade)wallstatus;
        upgrades.prepUpgrade = (PrepUpgrade)prepstatus;
        upgrades.tableCount = tables;
        upgrades.snackCount = snacks;
        upgrades.screens[0] = screen0 != 0;
        upgrades.screens[1] = screen1 != 0;
        upgrades.screens[2] = screen2 != 0;
        PlayerPrefs.Save();
        SceneManager.LoadScene("StageMap");
    }

    IEnumerator RiseLose()
    {
        while (loseCanvas.GetComponent<RectTransform>().anchoredPosition.y < 0)
        {
            loseCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 1000 * Time.deltaTime);
            yield return null;
        }
        
        loseCanvas.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
       
    }

    IEnumerator RiseWin(int reward,int stars)
    {
        while (winCanvas.GetComponent<RectTransform>().anchoredPosition.y < 0)
        {
            winCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 1000 * Time.deltaTime);
            yield return null;
        }

        winCanvas.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(ShowStar(reward,0,stars));

        
    }

    IEnumerator ShowStar(int reward,int index,int star)
    {
        if(index < star)
        {
            stars[index].SetActive(true);
            stars[index].transform.localScale = new Vector3(2,2,2);
            float scalevalue = 2;
            while (stars[index].transform.localScale.x > 1.2f)
            {
                scalevalue -= 2 * Time.deltaTime;
                stars[index].transform.localScale = new Vector3(scalevalue, scalevalue, scalevalue);
                yield return null;
            }
            stars[index].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(ShowStar(reward,index + 1,star));
        }
        else
        {
            StartCoroutine(RiseMoney(reward));
        }
    }

    IEnumerator RiseMoney(int money)
    {
        float rewardText = 0;
        while (rewardText < money)
        {
            rewardText += 1000 * Time.deltaTime;
            reward.text = "" + (int)(rewardText);
            yield return null;
        }
        reward.text = "" + money;
    }
}
