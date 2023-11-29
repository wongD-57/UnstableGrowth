using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedGOPoisonPill : MonoBehaviour
{
    // Start is called before the first frame update

    public float durationOfLife = 10000;
    private float timeOfCreation;

    void Start()
    {
        timeOfCreation = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeOfCreation > durationOfLife)
        {
            // print("Destrony Self");
            Destroy(gameObject);
        }
    }
}
