﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float moveSpeed;
    public Rigidbody2D rig;
    public float jumpForce;


    void FixedUpdate() {
        float xInput = Input.GetAxis("Horizontal");
        // float yInput = Input.GetAxis("Vertical");

        rig.velocity = new Vector2(xInput * moveSpeed, rig.velocity.y);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded()) {
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }  
    }

    bool IsGrounded() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -0.1f, 0), Vector2.down, 0.2f);
        return hit.collider != null;
    }
}
