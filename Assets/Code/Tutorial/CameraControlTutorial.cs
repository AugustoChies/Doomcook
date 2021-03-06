﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlTutorial : MonoBehaviour
{
    public Transform target;
    public Vector3 velocity = Vector3.one;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void Start()
    {
        this.GetComponent<Camera>().transparencySortMode = TransparencySortMode.Orthographic;
    }

    void FixedUpdate()
    {        
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
            transform.position = smoothedPosition;        
    }
}
