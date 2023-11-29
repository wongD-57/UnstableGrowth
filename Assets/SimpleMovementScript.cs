using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovementScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 MovmentVector = new Vector3(0,0,0);

    // Update is called once per frame
    void Update()
    {
        transform.position += MovmentVector*Time.deltaTime;
    }
}
