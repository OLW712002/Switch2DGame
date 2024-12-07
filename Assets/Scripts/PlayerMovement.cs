using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] float jumpForce = 1.0f;

    Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("Jump");
            myRigidbody.velocity = new Vector2(0f, jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
        FlipPlayer();
    }

    private void FlipPlayer()
    {
        myRigidbody.transform.localScale = new Vector2(Math.Sign(moveSpeed), 1.0f);
    }
}
