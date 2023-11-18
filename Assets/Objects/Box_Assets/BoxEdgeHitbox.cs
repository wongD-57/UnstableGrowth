using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEdgeHitbox : MonoBehaviour
{

    private Collider edgeCollider;

    public float angleTolerance;

    float yTolerance;

    void Start() {
        edgeCollider = GetComponent<Collider>();

    }

    void Update() {
        angleTolerance = transform.parent.parent.transform.GetComponent<BoxOverallHitbox>().edgeHitboxTolerance;

        yTolerance = Mathf.Sin(angleTolerance * Mathf.Deg2Rad);
    }

    void FixedUpdate() {
        // Debug.Log(transform.right.y);
        if (transform.right.y > yTolerance) {
            Debug.DrawRay(transform.position, transform.right * 2, Color.blue);
            edgeCollider.enabled = true;
        } else {
            Debug.DrawRay(transform.position, transform.right * 2, Color.red); 
            edgeCollider.enabled = false;
        }
    }
}
