using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    private bool wPressed;
    private bool aPressed;
    private bool sPressed;
    private bool dPressed;

    public float moveForce;

    private void Start()
    {
        wPressed = false;
        aPressed = false;
        sPressed = false;
        dPressed = false;

        moveForce = 500f;
    }

    private void Update()
    {
        GameStateMaschine gMaschine = GameObject.Find("GameManager").GetComponent<GameStateMaschine>();

        if (gMaschine.gState == GameStateMaschine.GameState.Map)
        {
            if (Input.GetKey("w"))
            {
                wPressed = true;
            }
            if (Input.GetKey("a"))
            {
                aPressed = true;
            }
            if (Input.GetKey("s"))
            {
                sPressed = true;
            }
            if (Input.GetKey("d"))
            {
                dPressed = true;
            }
        }      
    }

    private void FixedUpdate()
    {
        if (wPressed)
        {
            rb.AddForce(0, 0, moveForce * Time.deltaTime);
            wPressed = false;
        }
        if (aPressed)
        {
            rb.AddForce(-moveForce * Time.deltaTime, 0, 0);
            aPressed = false;
        }
        if (sPressed)
        {
            rb.AddForce(0, 0, -moveForce * Time.deltaTime);
            sPressed = false;
        }
        if (dPressed)
        {
            rb.AddForce(moveForce * Time.deltaTime, 0, 0);
            dPressed = false;
        }
    }

}
