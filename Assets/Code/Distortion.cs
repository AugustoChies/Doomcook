using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Distortion : MonoBehaviour
{
    public bool activated;
    public float distortionTime;
    private float timer;
    private LensDistortion lensDistortion;
    public PostProcessVolume ppv;
    private bool increase = true;
    private bool increaseX = true;
    private bool increaseY = true;


    private void Start()
    {
        ppv.profile.TryGetSettings(out lensDistortion);
        lensDistortion.enabled.value = false;
        lensDistortion.centerX.value = 0.0f;
        lensDistortion.centerY.value = 0.0f;
        lensDistortion.intensity.value = 0.0f;
    }

    void Update()
    {
        if(activated)
        {
            timer -= Time.deltaTime;

            if(increase)
            {
                lensDistortion.intensity.value += 200 * Time.deltaTime;
                if (lensDistortion.intensity.value >= 70.0f)
                {
                    increase = false;
                }
            }
            else
            {
                lensDistortion.intensity.value -= 200 * Time.deltaTime;
                if (lensDistortion.intensity.value <= -70.0f)
                {
                    increase = true;
                }
            }

            if (increaseX)
            {
                lensDistortion.centerX.value += 2 * Time.deltaTime;
                if (lensDistortion.centerX.value >= 0.8f)
                {
                    increaseX = false;
                }
            }
            else
            {
                lensDistortion.centerX.value -= 2 * Time.deltaTime;
                if (lensDistortion.centerX.value <= -0.8f)
                {
                    increaseX = true;
                }
            }

            if (increaseY)
            {
                lensDistortion.centerY.value += 3 * Time.deltaTime;
                if (lensDistortion.centerY.value >= 0.8f)
                {
                    increaseY = false;
                }
            }
            else
            {
                lensDistortion.centerY.value -= 3 * Time.deltaTime;
                if (lensDistortion.centerY.value <= -0.8f)
                {
                    increaseY = true;
                }
            }

            if (timer <= 0)
            {
                activated = false;
            }
        }
        else
        {
            if(lensDistortion.enabled.value)
            {
                if(lensDistortion.intensity.value != 0.0f)
                {
                    if (lensDistortion.intensity.value > -2.0f && lensDistortion.intensity.value < 2.0f)
                    {
                        lensDistortion.intensity.value = 0.0f;
                    }

                    if (lensDistortion.intensity.value > 0.0f)
                    {
                        lensDistortion.intensity.value -= 70 * Time.deltaTime;
                    }
                    else
                    {
                        lensDistortion.intensity.value += 70 * Time.deltaTime;
                    }                    
                }
                else
                {
                    lensDistortion.enabled.value = false;
                }
            }
        }
    }

    public void Activate()
    {
        activated = true;
        timer = distortionTime;
        lensDistortion.enabled.value = true;
    }
}
