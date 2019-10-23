using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameState gs;
    public KeycodesReference keys;
    public Transform target,widetarget;
    public Vector3 velocity = Vector3.one;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void Start()
    {
        gs.wide = false;
        this.GetComponent<Camera>().transparencySortMode = TransparencySortMode.Orthographic;
    }

    private void Update()
    {
        if(Input.GetKeyDown(keys.wideCamera))
        {
            gs.wide = !gs.wide;
        }
    }

    void FixedUpdate()
    {
        if (gs.wide)
        {            
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, widetarget.position, ref velocity, smoothSpeed);
            transform.position = smoothedPosition;
        }
        else
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
