using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBox : MonoBehaviour
{
    [SerializeField] private float maxDrop = 30f;
    

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -maxDrop) {
            Destroy(gameObject);
        }
    }
}
