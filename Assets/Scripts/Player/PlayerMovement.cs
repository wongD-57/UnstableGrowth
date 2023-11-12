using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float inputMove;
    Rigidbody rb;
    [SerializeField] private bool grounded = false;

    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float jumpForce = 5;

    public void ReadInput(float input) {
        inputMove = input;
    }

    public void Jump() {
        // If grounded, add force to jump up.
        if (grounded) {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            grounded = false;
        }
        
        // Else if not grounded, don't do anything.
        
    }

    public void Grounded(bool groundValue) {
        grounded = groundValue;
    }
    
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        // During every fixed update, translate the player left or right according to the input.
        rb.AddForce(new Vector3(inputMove * moveSpeed, 0, 0), ForceMode.Impulse);
    }
    
}
