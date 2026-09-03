using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float moveForce =5f;
    float jumpForce =400f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * moveForce);
            spriteRenderer.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * moveForce);
            spriteRenderer.flipX = false;
        }
        if (Input.GetKey(KeyCode.W))
        {
            spriteRenderer.flipY = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            spriteRenderer.flipY = true;
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
   
}
