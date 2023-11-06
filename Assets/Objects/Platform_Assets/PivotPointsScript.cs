using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotPointsScript : MonoBehaviour
{

    public GameObject leftPivot;
    public GameObject rightPivot;

    [Range(-5,5)]
    public float PivotPointMovementRate = -1f;

    [Range(0,10)]
    public float PivotPointStartingWidth = 2f;
    public float PivotPointStartingHeight = -2f;

    public float MinPointWidth = 2f;
    public float MaxPointWidth = 8f;


    // Start is called before the first frame update
    void Start()
    {
        // float distanceholder = transform.position.x;

        leftPivot.transform.position = new Vector3(transform.position.x-PivotPointStartingWidth,transform.position.y + PivotPointStartingHeight,transform.position.z);
        rightPivot.transform.position = new Vector3(transform.position.x+PivotPointStartingWidth,transform.position.y + PivotPointStartingHeight,transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

        float distanceBetweenPivots = Mathf.Abs(leftPivot.transform.position.x - rightPivot.transform.position.x);



        if(distanceBetweenPivots < MaxPointWidth && distanceBetweenPivots > MinPointWidth)
        {
            leftPivot.transform.position += new Vector3(-PivotPointMovementRate * Time.deltaTime,0,0);
            rightPivot.transform.position += new Vector3(PivotPointMovementRate * Time.deltaTime,0,0);
        }

    }
}
