﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoneButtonCutscene : MonoBehaviour
{
    public void Done()
    {
        SceneManager.LoadScene("StageMap");
    }
     

}
