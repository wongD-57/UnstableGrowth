using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headerFooterScrollScript : MonoBehaviour
{

    public enum headerFooterType
    {
        Header,
        Footer
    }

    public headerFooterType objectType;

    private float initialHeight;
    public float travelSpace;
    public float scrollSpeed = 50;

    private float distCounter = 0;

    public bool isMoving = false;

    public RectTransform MovingCanvas;
    
    void Start()
    {
        initialHeight = MovingCanvas.localPosition[2];

        switch(objectType){
            case headerFooterType.Header:
                isMoving = true;
                break;

            case headerFooterType.Footer:
                isMoving = false;
                break;
        }
    }



    void Update()
    {
        if(distCounter>travelSpace)
        {
            isMoving = false;
        }

        if(isMoving){
            distCounter += scrollSpeed*Time.deltaTime;
            MovingCanvas.localPosition  += new Vector3(0,scrollSpeed*Time.deltaTime,0);
        }
    }

}
