using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float moveForce =5f;
    float jumpForce =200f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    private bool isGrounded;
    private float dirX = 0f;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        Move();
        Jump();
        MoveAnimation();
    }
    void FixedUpdate()
    {
        
    }
    void Move()
    {
        rb.velocity = new Vector2(dirX * moveForce, rb.velocity.y);

        if (dirX > 0) spriteRenderer.flipX = false;
        if (dirX < 0) spriteRenderer.flipX = true;
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
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    private void MoveAnimation()
    {
        if (isGrounded)
        {
            if (dirX != 0f)
                anim.SetInteger("state", 1); // Run
            else
                anim.SetInteger("state", 0); // Idle
        }
        else
        {
            if (rb.velocity.y > 0.01f)
                anim.SetInteger("state", 2); // Jump
            else
                anim.SetInteger("state", 3); // Fall
        }
    }
}

