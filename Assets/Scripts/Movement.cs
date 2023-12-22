using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Rigidbody2D rb;
    private Vector2 movement;
    public bool isGrounded;
    public float jumpInput;

    public float acceleration = 0.1f;
    public float speed = 0.1f;
    public float jumpForce = 1f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Walking();
        Jumping();
    }

    void Walking() {
        movement.x = Input.GetAxis("Horizontal");

        if (Math.Abs(rb.velocity.x) > speed) {
            return;
        }
        rb.AddForce(movement * acceleration * Time.deltaTime);
    }

    void Jumping() {
        jumpInput = Input.GetAxis("Jump");

        if (jumpInput == 0f) {
            return;
        }
        if (isGrounded == false) {
            return;
        }

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        isGrounded = false;
    }

    void OnCollisionStay2D (Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            isGrounded = true;
        }

    }

}
