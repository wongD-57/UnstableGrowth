using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    
    Vector2 input = Vector2.zero;

    public float cursorSpeedProportional = 0.1f; // Proportional Speed of Cursor relative to screen size

    //RectTransform m_rTransform;

    private GameObject cameraObject;

    Vector3 cameraPosition;

    private GameObject hitObject;

    public float cubeScaleSpeed = 0.1f;

    public float objectPlanePosition = 0.75f;



    public void ReadInput(Vector2 inputCursor) {
        input = inputCursor;
    }

    public void MakeGrow() {
        Collider[] colliders = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y, objectPlanePosition), transform.localScale.x);
        
        foreach (Collider nearbyObject in colliders) {
            
            if (nearbyObject.GetComponent<BoxScale>() != null) {
                nearbyObject.GetComponent<BoxScale>().MakeGrow(1/colliders.Length);
            }
        }

    }

    public void MakeShrink() {
        Collider[] colliders = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y, objectPlanePosition), transform.localScale.x);
        
        foreach (Collider nearbyObject in colliders) {
            
            if (nearbyObject.GetComponent<BoxScale>() != null) {
                nearbyObject.GetComponent<BoxScale>().MakeShrink(1/colliders.Length);
            }
        }

    }

    void Start() {
        //m_rTransform = GetComponent<RectTransform>();

        cameraObject = GameObject.Find("Main Camera");

    }

    void Update() {
        //m_rTransform.anchoredPosition += new Vector2(input.x * cursorSpeedProportional, input.y * cursorSpeedProportional);
        transform.position += new Vector3(input.x * cursorSpeedProportional, input.y * cursorSpeedProportional, 0);
    }
}
