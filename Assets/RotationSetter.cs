using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SimpleRotationScript SRScript = GetComponent<SimpleRotationScript>();
        SRScript.rotationVector = new Vector3(0,0,0);
    }

    // Update is called once per frame
}
