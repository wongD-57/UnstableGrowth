using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotationScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 rotationVector = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationVector*Time.deltaTime);
    }
}
