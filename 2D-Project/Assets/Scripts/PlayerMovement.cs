using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRB;

    private float xDirection;

    public float movementSpeed = 5;

    public float jumpForce = 10;

    public Transform[] groundCheck;

    public LayerMask groundMask;

    public float checkGroundDistance = 0.2f;

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        xDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            myRB.velocity = new Vector2(myRB.velocity.x, jumpForce);
        }
    }

    private bool isGrounded()
    {
        for (int i = 0; i < groundCheck.Length; i++)
        {
            if (Physics2D.Raycast(groundCheck[i].position, -groundCheck[i].up, checkGroundDistance, groundMask))
            {
                return true;
            }
        }
        return false;
    }

    private void FixedUpdate()
    {
        myRB.velocity = new Vector2(xDirection * movementSpeed, myRB.velocity.y);
    }
}