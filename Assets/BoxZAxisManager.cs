using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxZAxisManager : MonoBehaviour
{

    private Vector3 previousScale;

    private float platformZDatum;
    // Start is called before the first frame update
    void Start()
    {
        GameObject GOHolder = GameObject.Find("PlatformParent");
        // platformZDatum = GOHolder.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale != previousScale)
        {
            previousScale = transform.localScale;
            transform.position = new Vector3(transform.position[0],transform.position[1],platformZDatum+(transform.localScale[0]/2));
        }
    }
}
