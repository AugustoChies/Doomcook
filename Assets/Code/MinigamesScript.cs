using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigamesScript : MonoBehaviour {
    public GameState gs;
    public KeycodesReference inputMap;
    private bool takeInput;
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
    public float additionalSpeed;
    Transform beginning;
    Transform end;
    GameObject bar;

    [Header("Mash game variables")]
    public float gradualRegrowth;
    GameObject button;
    Vector3 originalScale;

    [Header("Grate game variables")]
    bool grateTick;
    public GameObject Lbutton,Rbutton;
    // Use this for initialization
    void Start() {
        takeInput = false;
        gs.minigame = false;
        beginning = cutMinigame.transform.Find("Beginning");
        end = cutMinigame.transform.Find("Ending");
        bar = cutMinigame.transform.Find("Bar").gameObject;
        button = mashMinigame.transform.Find("Button").gameObject;
        Lbutton = grateMinigame.transform.Find("Left").gameObject;
        Rbutton = grateMinigame.transform.Find("Right").gameObject;

        originalScale = button.transform.localScale;
    }

    void LateUpdate()
    {
        if(gs.minigame)
        {
            takeInput = true;
        }
    }

    public void StartCutting(float timeModifier)
    {
        takeInput = false;
        gs.minigame = true;
        cutMinigame.SetActive(true);
        StartCoroutine(CutGame(timeModifier));
    }

    public void StartMashing(float timeModifier)
    {
        takeInput = false;
        gs.minigame = true;
        button.transform.localScale = originalScale;
        mashMinigame.SetActive(true);
        StartCoroutine(MashGame(timeModifier));
    }

    public void StartGrating(float timeModifier)
    {
        takeInput = false;
        gs.minigame = true;        
        grateMinigame.SetActive(true);
        StartCoroutine(GrateGame(timeModifier));
    }

    IEnumerator CutGame(float modifier)
    {
        GameObject middle = cutMinigame.transform.Find("Middle").gameObject;
        bool right = true;
        float elapsedTime = cutTime + modifier;
        float currentSpeed = barSpeed;
        float barPosition = 0;
        bar.transform.position = beginning.position;
        while (elapsedTime > 0)
        {
            if(Input.GetKeyDown(inputMap.interact) && takeInput)
            {
                Color ocolor = middle.GetComponent<Image>().color;
                if (barPosition > 0.5 - middleTolerance && barPosition < 0.5 + middleTolerance)
                {
                    elapsedTime -= cutRedTime;
                    currentSpeed += additionalSpeed;                    
                    middle.GetComponent<Image>().color = Color.green;
                }
                else
                {
                    middle.GetComponent<Image>().color = Color.red;
                }
                barPosition = 0;
                right = true;
                StartCoroutine(ChangeBackColor(ocolor, middle));
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

    IEnumerator ChangeBackColor(Color c,GameObject obj)
    {
        yield return new WaitForSeconds(0.3f);
        obj.GetComponent<Image>().color = c;
    }

    IEnumerator MashGame(float modifier)
    {
        float elapsedTime = cutTime + modifier;
        while (elapsedTime > 0)
        {
            if(button.transform.localScale.x < originalScale.x)
            {
                button.transform.localScale += new Vector3(originalScale.x,originalScale.y,originalScale.y) * gradualRegrowth * Time.deltaTime; 
            }


            if (Input.GetKeyDown(inputMap.interact) && takeInput)
            {                
                elapsedTime -= mashRedTime;
                button.transform.localScale = originalScale / 2;
            }
            elapsedTime -= Time.deltaTime;


            yield return null;
        }
        mashMinigame.SetActive(false);
        gs.minigame = false;
    }

    IEnumerator GrateGame(float modifier)
    {
        float elapsedTime = grateTime + modifier;

        grateTick = false;
        Lbutton.GetComponent<Image>().color = Color.green;
        Rbutton.GetComponent<Image>().color = Color.white;
        while (elapsedTime > 0)
        {
            if(grateTick)
            {
                if (Input.GetKey(inputMap.interact))
                {
                    grateTick = false;
                    Lbutton.GetComponent<Image>().color = Color.green;
                    Rbutton.GetComponent<Image>().color = Color.white;
                    elapsedTime -= grateRedTime;
                }
            }
            else
            {
                if (Input.GetKey(inputMap.alternateminigame))
                {
                    grateTick = true;
                    Lbutton.GetComponent<Image>().color = Color.white;
                    Rbutton.GetComponent<Image>().color = Color.green;
                }
            }


            
            elapsedTime -= Time.deltaTime;


            yield return null;
        }
        grateMinigame.SetActive(false);
        gs.minigame = false;
    }
}
