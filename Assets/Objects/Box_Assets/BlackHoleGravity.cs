using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleGravity : MonoBehaviour
{
    
    [SerializeField] private float influenceRadiusMax = 7f;
    [SerializeField] private float influenceRadiusMin = 3f;
    [SerializeField] private float gravityForce = 150f;

    void FixedUpdate() {
        // Every frame

        Collider[] colliders = Physics.OverlapSphere(transform.position, influenceRadiusMax);
        
        foreach (Collider nearbyObject in colliders) {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null) {
                float distanceToObject = Vector3.Magnitude(rb.transform.position - transform.position); 
                // Scale the magnitude of the force based on distance of the object
                float forceMultiplier = Mathf.Clamp((influenceRadiusMax - distanceToObject)/(influenceRadiusMax - influenceRadiusMin), 0, 1);
                rb.AddForce(Vector3.Normalize(transform.position - nearbyObject.transform.position) * forceMultiplier * gravityForce * transform.localScale.x / Time.fixedDeltaTime);
            }
        }
    }
}
