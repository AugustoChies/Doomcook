﻿using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Serializable]  
    
    public class MoveAxis
    {
        public KeyCode Positive;
        public KeyCode Negative;

        public MoveAxis(KeyCode positive, KeyCode negative)
        {
            Positive = positive;
            Negative = negative;
        }

        public static implicit operator float(MoveAxis axis)
        {
            return (Input.GetKey(axis.Positive)
                ? 1.0f : 0.0f) -
                (Input.GetKey(axis.Negative)
                ? 1.0f : 0.0f);
        }
    }

    public FloatVariable speed;
    public KeycodesReference controls;
    public MoveAxis Horizontal;
    public MoveAxis Vertical;


    [SerializeField]
    private Vector3 angles;
    private Quaternion rotation;
    public Transform iconMaster;
    public Animator anim;
    public GameState gs;


    private void Start()
    {
        iconMaster = this.gameObject.GetComponent<PlayerIcons>().iconmaster;
        rotation = Quaternion.Euler(angles);
        Horizontal = new MoveAxis(controls.right, controls.left);
        Vertical = new MoveAxis(controls.up, controls.down);
        anim = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        if (!gs.minigame && !gs.wide && !gs.upgrading && !gs.tutorial && !gs.end)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Vector3 moveNormal = new Vector3(Horizontal, 0.0f, Vertical).normalized;

            this.transform.LookAt(transform.position + moveNormal);
            iconMaster.rotation = rotation;
            if(Horizontal != 0 || Vertical != 0)
            {
                anim.SetBool("Moving", true);
            }
            else
            {
                anim.SetBool("Moving", false);
            }
            gameObject.GetComponent<Rigidbody>().MovePosition(this.transform.position + moveNormal * Time.deltaTime * speed.Value);
        }
        else
        {
            anim.SetBool("Moving", false);
        }
    }
}
