using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBackgroundMove : MonoBehaviour
{

    float backgroundMoveSpeed = 3f;

    [SerializeField] private float backgroundMaxHeight = 10f;

    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -backgroundMaxHeight) {
            transform.position = new Vector3(0, backgroundMaxHeight, 0);
        }
        
        transform.position += new Vector3(0, -backgroundMoveSpeed * Time.deltaTime, 0);
    }
}
