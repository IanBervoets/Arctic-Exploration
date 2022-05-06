using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float jumpForce = 5;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider2D;
    

    private void Awake()    
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        //Flips character model when moving left or right
        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //Controls Character movement
        body.velocity = new Vector2(Input.GetAxis("Horizontal")* speed, body.velocity.y);

        if (Input.GetKey(KeyCode.UpArrow) && isGrounded())
        {
            Jump();
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit2D =
            Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return false;
    }
}
