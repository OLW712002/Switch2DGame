using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehavior : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2.0f;
    Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(moveSpeed, 0f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            moveSpeed = -moveSpeed;
            FlipSprite();
        }
    }

    private void FlipSprite()
    {
        myRigidbody.transform.localScale = new Vector2(Mathf.Sign(moveSpeed), myRigidbody.transform.localScale.y);
    }
}
