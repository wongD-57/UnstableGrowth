using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    Rigidbody rb;
    Collider groundCollider;

    public bool dropPressed = false;


    // public void Drop(bool dropInput) {
    //     dropPressed = dropInput;
    // }
    
    void Start() {
        rb = GetComponent<Rigidbody>();

        groundCollider = transform.GetChild(0).transform.GetComponent<Collider>();
    }

    void FixedUpdate() {
        // print("dropPressed="+dropPressed);
        if (rb.velocity.y > 0 || dropPressed) {
            groundCollider.enabled = false;
        } else {
            groundCollider.enabled = true;
        }
    }
}
