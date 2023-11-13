using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovementScript : MonoBehaviour
{
    
    
    public float rotationRate = 10f;
    public float riseRate = 1f;

    private Vector3 rotationVector;
    
    void Update()
    {
        rotationVector = new Vector3(0,rotationRate,0);
        transform.Rotate(rotationVector*Time.deltaTime);
        transform.position += new Vector3(0,riseRate*Time.deltaTime,0);
    }
}
