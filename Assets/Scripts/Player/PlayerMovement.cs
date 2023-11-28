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
    
    public float playerDepth = 0.1f;

    public Collider zAxisCollider;

    private float platformZDatum;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();

        GameObject GOHolder = GameObject.Find("PlatformParent");
        platformZDatum = GOHolder.transform.position.z;
        transform.position = new Vector3(transform.position.x,transform.position.y,platformZDatum);
    }

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
    

    void FixedUpdate() {
        rb.AddForce(new Vector3(inputMove * moveSpeed, 0, 0), ForceMode.Impulse);
        zAxisMover();
    }

    void zAxisMover(){

        // RaycastHit hit;
        // Vector3 vectorStart = transform.position - new Vector3(0,0.6f,0);
        // Debug.DrawRay(vectorStart,Vector3.down*0.5f,Color.black);

    }

    void lerpPlayer(float zValue)
    {
        transform.position = new Vector3(transform.position[0],transform.position[1],zValue);
    }
    
    
}
