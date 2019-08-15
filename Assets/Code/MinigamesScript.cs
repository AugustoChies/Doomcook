using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigamesScript : MonoBehaviour {
    public bool minigameOn;
    public KeycodesReference inputMap;
    [Header("Minigame time values")]
    public float cutTime;
    public float mashTime;
    public float grateTime;

    [Header("Minigame time reduction values")]
    public float cutRedTime;
    public float mashRedTime;
    public float grateRedTime;

    [Header("References")]
    public GameObject cutMinigame;
    public GameObject mashMinigame;
    public GameObject grateMinigame;

    [Header("Cut game variables")]
    public float barSpeed;
    public float middleTolerance;
    Transform beginning;
    Transform end;
    GameObject bar;
    // Use this for initialization
    void Start() {
        beginning = cutMinigame.transform.Find("Beginning");
        end = cutMinigame.transform.Find("Ending");
        bar = cutMinigame.transform.Find("Bar").gameObject;
    }

    public void StartCutting(float timeModifier)
    {
        StartCoroutine(CutGame(timeModifier));
    }

    IEnumerator CutGame(float modifier)
    {
        minigameOn = true;
        bool right = true;
        float elapsedTime = cutTime + modifier;
        float barPosition = 0;
        bar.transform.position = beginning.position;
        while (elapsedTime > 0)
        {
            if(Input.GetKeyDown(inputMap.interact))
            {

            }
            bar.transform.position = Vector3.Lerp(beginning.position,end.position,barPosition);
            elapsedTime -= Time.deltaTime;


            yield return null;
        }
    }
}
