using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelNode : MonoBehaviour
{
    public int stageID;
    public Resources resources;
    bool disabled;
    bool expanded;
    public Color active,inactive;
    public GameObject levelDescription;       
    GameObject star1, star2, star3;
    Vector3 camPos;
    public MapCamera cam;
    // Start is called before the first frame update
    void Start()
    {
        if(stageID > 0 && resources.starsPerStage[stageID-1]< 1)
        {
            disabled = true;
        }
        if(disabled)
        {
            this.GetComponent<SpriteRenderer>().color = inactive;
        }

        star1 = levelDescription.transform.Find("Star1").gameObject;
        star2 = levelDescription.transform.Find("Star2").gameObject;
        star3 = levelDescription.transform.Find("Star3").gameObject;
        camPos = this.transform.Find("CamSpot").position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if (!disabled && !expanded)
        {
            StartCoroutine(ExpandBox());
            cam.target = camPos;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!disabled)
            {
                SceneManager.LoadScene("Stage" + stageID);
            }
        }
    }

    private void OnMouseExit()
    {
        if (!disabled && expanded)
        {
            StartCoroutine(RetractBox());
        }
    }

    IEnumerator ExpandBox()
    {
        expanded = true;
        levelDescription.SetActive(true);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        if(resources.starsPerStage[stageID] > 2)
        {
            star3.SetActive(true);
        }
        if (resources.starsPerStage[stageID] > 1)
        {
            star2.SetActive(true);
        }
        if (resources.starsPerStage[stageID] > 0)
        {
            star1.SetActive(true);
        }


        for (float i = levelDescription.transform.localScale.y; i <= 1.0f; i += 4 * Time.deltaTime)
        {
            if (!expanded)
            {
                break;
            }
            levelDescription.transform.localScale = new Vector3(1.0f, i, 1.0f);
            yield return null;
        }
        if (expanded)
        {
            levelDescription.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    IEnumerator RetractBox()
    {
        expanded = false;

        for (float i = levelDescription.transform.localScale.y; i > 0.1f; i -= 4 * Time.deltaTime)
        {
            if(expanded)
            {
                break;
            }
            levelDescription.transform.localScale = new Vector3(1.0f, i, 1.0f);
            yield return null;
        }
        if (!expanded)
        {
            levelDescription.transform.localScale = new Vector3(1.0f, 0.0041264f, 1.0f);
            levelDescription.SetActive(false);
        }
    }
}
