using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

public class DialogBoxControl : MonoBehaviour
{
    public GameObject portrait;
    public GameObject box;
    public List<string> filestack;
    public string fulltext;
    [Tooltip("box expansion speed")]
    public float expandSpeed;
    [Tooltip("Delay between letters")]
    public float letterDelay;
    [Tooltip("Time for end of sentence blinks")]
    public float arrowBlink;
    [Tooltip("Time text stays on screen before closing")]
    bool expanded;
    public GameObject triang;
    public int textTriggers = 0;
    public GameState gs;
    public short stageID;
    

    bool inputlock = false;

    
    // Use this for initialization
    void Awake()
    {
        triang = this.transform.Find("Dialoguebox/Triangle").gameObject;
        gs.upgrading = false;
        gs.tutorial = true;
        filestack = new List<string>();
        ReadScriptfromFile();
       
    }

    void Update()
    {
        if (!expanded && textTriggers > 0)
        {
            StartCoroutine("ExpandBox");            
            NewText();
        }

        if (gs.tutorial)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                textTriggers = 0;
                StartCoroutine("RetractBox");
                StartCoroutine(DelayedPause());
            }
            inputlock = false;
        }
    }


    public void NewText()
    {
        textTriggers--;
        triang.SetActive(false);
        if (filestack.Count > 0)
        {
            fulltext = filestack[0];
            filestack.RemoveAt(0);
            box.GetComponentInChildren<TextMeshProUGUI>().text = fulltext;
            box.GetComponentInChildren<TextMeshProUGUI>().ForceMeshUpdate();

            box.GetComponentInChildren<TextMeshProUGUI>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }
        else
        {
            fulltext = "Roteiristas preguiçosos";
        }

        StartCoroutine("Typetext");
    }


    IEnumerator DelayedPause()
    {
        for (float i = 0; i < 0.25f; i+= 1* Time.deltaTime)
        {
            yield return null;
        }

        gs.tutorial = false;
        if (SceneManager.GetActiveScene().name != "StageTutorial")
        {
            gs.upgrading = true;
        }
        
    }

    IEnumerator ExpandBox()
    {
        expanded = true;
        box.SetActive(true);
        portrait.SetActive(true);

        for (float i = 0; i <= 1.0f; i += expandSpeed * Time.deltaTime)
        {
            this.gameObject.transform.localScale = new Vector3(1.0f, i, 1.0f);
            yield return null;
        }
    }

    IEnumerator RetractBox()
    {
        expanded = false;

        for (float i = 1.0f; i > 0.1f; i -= expandSpeed * Time.deltaTime)
        {
            this.gameObject.transform.localScale = new Vector3(1.0f, i, 1.0f);
            yield return null;
        }
        box.SetActive(false);
        portrait.SetActive(false);
    }

    bool pressed = false;
    IEnumerator Typetext()
    {
        int currentindex = 0;
        TMP_Text tmtext = box.GetComponentInChildren<TextMeshProUGUI>();
        int charcount = tmtext.textInfo.characterCount;
        Color32 c0 = tmtext.color;
        c0 = new Color32(0, 0, 0, 255);



        pressed = false;
        while (currentindex < charcount - 1)
        {
            //GAMBIARRA PRA MOSTRAR A PRIMEIRA LETRA

            Color32[] newVertexColors;

            int materialIndex = tmtext.textInfo.characterInfo[0].materialReferenceIndex;

            newVertexColors = tmtext.textInfo.meshInfo[materialIndex].colors32;

            int vertexIndex = tmtext.textInfo.characterInfo[0].vertexIndex;


            newVertexColors[vertexIndex + 0] = c0;
            newVertexColors[vertexIndex + 1] = c0;
            newVertexColors[vertexIndex + 2] = c0;
            newVertexColors[vertexIndex + 3] = c0;

            tmtext.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);

            ////////////////////

            // Get the index of the material used by the current character.
            materialIndex = tmtext.textInfo.characterInfo[currentindex].materialReferenceIndex;

            newVertexColors = tmtext.textInfo.meshInfo[materialIndex].colors32;

            // Get the index of the first vertex used by this text element.
            vertexIndex = tmtext.textInfo.characterInfo[currentindex].vertexIndex;

            if (tmtext.textInfo.characterInfo[currentindex].isVisible)
            {
                newVertexColors[vertexIndex + 0] = c0;
                newVertexColors[vertexIndex + 1] = c0;
                newVertexColors[vertexIndex + 2] = c0;
                newVertexColors[vertexIndex + 3] = c0;

                // New function which pushes (all) updated vertex data to the appropriate meshes when using either the Mesh Renderer or CanvasRenderer.
                tmtext.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);

                // This last process could be done to only update the vertex data that has changed as opposed to all of the vertex data but it would require extra steps and knowing what type of renderer is used.
                // These extra steps would be a performance optimization but it is unlikely that such optimization will be necessary.
            }
           

            currentindex++;
             
                for (float i = 0; i < letterDelay; i += 1 * Time.deltaTime)
                {
                    if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && !inputlock)
                    {
                        currentindex = charcount;
                        pressed = true;
                        inputlock = true;
                        break;
                    }
                    yield return null;
                }
                     
        }
       

        StartCoroutine("WaitText");
        
    }

    IEnumerator WaitText()
    {
        box.GetComponentInChildren<TextMeshProUGUI>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        int currentindex = 0;
        TMP_Text tmtext = box.GetComponentInChildren<TextMeshProUGUI>();
        int charcount = tmtext.textInfo.characterCount;
        Color32 c0 = tmtext.color;
        c0 = new Color32(0, 0, 0, 255);


        while (currentindex < charcount)
        {           

            // Get the index of the material used by the current character.
            int materialIndex = tmtext.textInfo.characterInfo[currentindex].materialReferenceIndex;

            Color32[] newVertexColors = tmtext.textInfo.meshInfo[materialIndex].colors32;

            // Get the index of the first vertex used by this text element.
            int vertexIndex = tmtext.textInfo.characterInfo[currentindex].vertexIndex;

            // Only change the vertex color if the text element is visible.
            if (tmtext.textInfo.characterInfo[currentindex].isVisible)
            {
                
                    newVertexColors[vertexIndex + 0] = c0;
                    newVertexColors[vertexIndex + 1] = c0;
                    newVertexColors[vertexIndex + 2] = c0;
                    newVertexColors[vertexIndex + 3] = c0;
                
                // New function which pushes (all) updated vertex data to the appropriate meshes when using either the Mesh Renderer or CanvasRenderer.
                tmtext.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);

                // This last process could be done to only update the vertex data that has changed as opposed to all of the vertex data but it would require extra steps and knowing what type of renderer is used.
                // These extra steps would be a performance optimization but it is unlikely that such optimization will be necessary.
            }


            currentindex++;
        }
       
        pressed = false;
        while (!pressed)
        {
            for (float i = 0; i < arrowBlink; i+= 1 * Time.deltaTime)
            {                
                if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && !inputlock)
                {                    
                    pressed = true;
                    inputlock = true;
                    break;
                }                
                yield return null;
            }
            triang.SetActive(!triang.activeSelf);
        }

        if (textTriggers > 0)
        {
            NewText();
        }
        else
        {
            if (textTriggers <= 0)
            {
                gs.tutorial = false;
                if (SceneManager.GetActiveScene().name != "StageTutorial")
                {
                    gs.upgrading = true;
                }
            }
            StartCoroutine("RetractBox");
        }
    }

    public void ReadScriptfromFile()
    {
        string path = Application.streamingAssetsPath + "/dialog/Text" + stageID + ".txt";

        if (!File.Exists(path))
        {
            Debug.LogError("File path " + path + " not found");
        }
        else
        {
            filestack.Clear();
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                filestack.Add(sr.ReadLine());
            }
            sr.Close();
            fs.Close();
        }
        textTriggers = filestack.Count;
    }   
}
