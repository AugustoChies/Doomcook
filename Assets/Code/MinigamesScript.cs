using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigamesScript : MonoBehaviour {
    public GameState gs;
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
    public float timeReduction;
    public float additionalSpeed;
    Transform beginning;
    Transform end;
    GameObject bar;
    // Use this for initialization
    void Start() {
        gs.minigame = false;
        beginning = cutMinigame.transform.Find("Beginning");
        end = cutMinigame.transform.Find("Ending");
        bar = cutMinigame.transform.Find("Bar").gameObject;
    }

    public void StartCutting(float timeModifier)
    {
        gs.minigame = true;
        cutMinigame.SetActive(true);
        StartCoroutine(CutGame(timeModifier));
    }

    IEnumerator CutGame(float modifier)
    {
        bool right = true;
        float elapsedTime = cutTime + modifier;
        float currentSpeed = barSpeed;
        float barPosition = 0;
        bar.transform.position = beginning.position;
        while (elapsedTime > 0)
        {
            if(Input.GetKeyDown(inputMap.interact))
            {
                if(barPosition > 0.5 - middleTolerance && barPosition < 0.5 + middleTolerance)
                {
                    elapsedTime -= timeReduction;
                    currentSpeed += additionalSpeed;
                }
                else
                {
                    //miss sound
                }
                barPosition = 0;
                right = true;
            }

            if(right)
            {
                barPosition += currentSpeed * Time.deltaTime;
                if (barPosition >= 1.0f)
                    right = false;
            }
            else
            {
                barPosition -= currentSpeed * Time.deltaTime;
                if (barPosition <= 0.0f)
                    right = true;
            }



            bar.transform.position = Vector3.Lerp(beginning.position,end.position,barPosition);
            elapsedTime -= Time.deltaTime;


            yield return null;
        }
        cutMinigame.SetActive(false);
        gs.minigame = false;
    }
}
