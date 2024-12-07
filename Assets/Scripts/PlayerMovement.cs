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
    CapsuleCollider2D myBodyCollider;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
    }

    public void OnJump(InputValue value)
    {
        Vector2 myFeetPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - myBodyCollider.size.y / 2);
        Collider2D isGround = Physics2D.OverlapCircle(myFeetPosition, 0.25f, LayerMask.GetMask("Ground", "GravityInteract", "TeleportInteract"));
        if (value.isPressed && isGround != null)
        {
            Debug.Log("Jump");
            myRigidbody.velocity = new Vector2(0f, jumpForce);
        }
    }

    public void OnInteract(InputValue value)
    {
        if (value.isPressed && myBodyCollider.IsTouchingLayers(LayerMask.GetMask("GravityInteract", "TeleportInteract")))
        {
            if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("TeleportInteract")))
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - Math.Sign(myRigidbody.gravityScale) * 3.2f);
            myRigidbody.transform.localScale = new Vector2(Math.Sign(moveSpeed), -myRigidbody.transform.localScale.y);
            myRigidbody.gravityScale = -myRigidbody.gravityScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            moveSpeed = -moveSpeed;
            FlipPlayer();
        }
        
    }

    private void FlipPlayer()
    {
        myRigidbody.transform.localScale = new Vector2(Math.Sign(moveSpeed), myRigidbody.transform.localScale.y);
    }
}
