using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    // Raycast below and check if it runs into any overall hitbox or the environment

    LayerMask groundMask;
    RaycastHit hit;

    PlayerMovement PMHolder;

    [SerializeField] private float groundCheckDistance = 1.05f;

    void Start() {
        PMHolder = transform.parent.transform.GetComponent<PlayerMovement>();
        groundMask = (1 << 10) | (1 << 11) | (1 << 12);
    }

    void FixedUpdate() {
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundMask)) {
            // transform.parent.transform.GetComponent<PlayerMovement>().Grounded(true);
            PMHolder.Grounded(true);
        } else {
            // transform.parent.transform.GetComponent<PlayerMovement>().Grounded(false);
            PMHolder.Grounded(false);
        }
        Debug.DrawRay(transform.position, Vector3.down * groundCheckDistance, Color.green);
    }

    
}
