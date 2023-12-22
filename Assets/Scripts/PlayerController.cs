using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    public Animator animator;
    public SpriteRenderer sprite;

    private Rigidbody2D rb;
    private Vector2 movement;
    public bool isGrounded;
    public float jumpInput;

    public float acceleration = 0.1f;
    public float speed = 0.1f;
    public float jumpForce = 1f;

    public bool isActive = true;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update () {
        if (!isActive) {
            return;
        }

        Walking();
        Jumping();
    }

    void Walking () {
        movement.x = Input.GetAxis("Horizontal");

        if (movement.x < 0f) {
            sprite.flipX = true;
        } else if (movement.x > 0f) {
            sprite.flipX = false;
        }

        animator.SetFloat("Speed", Math.Abs(movement.x));

        if (Math.Abs(rb.velocity.x) > speed) {
            return;
        }
        rb.AddForce(movement * acceleration * Time.deltaTime);
    }

    void Jumping () {
        jumpInput = Input.GetAxis("Jump");

        if (jumpInput == 0f) {
            return;
        }
        if (isGrounded == false) {
            return;
        }

        animator.SetBool("IsJumping", true);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        isGrounded = false;
    }

    void OnLanding () {
        isGrounded = true;
        animator.SetBool("IsJumping", false);
    }

    void OnCollisionStay2D (Collision2D other) {

        if (other.gameObject.tag == "Ground") {
            OnLanding();
        }

    }

}
