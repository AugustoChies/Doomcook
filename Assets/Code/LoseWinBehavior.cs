using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseWinBehavior : MonoBehaviour
{
    public LifeControl life;
    public GameObject winCanvas;
    public GameObject loseCanvas;
    public LaneSpawner lane1, lane2, lane3;
    public LanesMonsterList monsterList;
    public GameState gs;
    public UpgradesStatus upgrade;
    bool done;
    // Start is called before the first frame update
    void Start()
    {
        done = false;
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
            }
            else if(lane1.monsters.Count == 0 && lane2.monsters.Count == 0 && lane3.monsters.Count == 0
                && monsterList.lanes[0].Count == 0 && monsterList.lanes[1].Count == 0 && monsterList.lanes[2].Count == 0)
            {
                StartCoroutine(RiseWin());
            }
        }
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

    IEnumerator RiseWin()
    {
        while (winCanvas.GetComponent<RectTransform>().anchoredPosition.y < 0)
        {
            winCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 1000 * Time.deltaTime);
            yield return null;
        }

        winCanvas.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

    }
}
