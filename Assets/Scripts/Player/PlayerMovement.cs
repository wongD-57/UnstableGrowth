using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float inputMove;
    Rigidbody rb;
    int grounded = 1;

    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float jumpForce = 5;

    public void ReadInput(float input) {
        inputMove = input;
    }

    public void Jump() {
        // If grounded, add force to jump up.
        if (grounded == 1) {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            print("Jump");
        }
        
        // Else if not grounded, don't do anything.
        
    }

    public void Drop() {
        // Ignore all hitboxes other than on see saw or boundaries of game
        print("Drop");
    }
    
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        // During every fixed update, translate the player left or right according to the input.
        rb.AddForce(new Vector3(inputMove * moveSpeed, 0, 0), ForceMode.Impulse);
    }
    

    
}
