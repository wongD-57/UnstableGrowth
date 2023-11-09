using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    
    Vector2 input = Vector2.zero;

    public float cursorSpeedProportional = 0.1f; // Proportional Speed of Cursor relative to screen size

    //RectTransform m_rTransform;

    GameObject cameraObject;

    Vector3 cameraPosition;



    public void ReadInput(Vector2 inputCursor) {
        input = inputCursor;
    }

    public void MakeGrow() {
        RaycastHit hit;
        cameraPosition = cameraObject.transform.position;
        if (Physics.Raycast(cameraPosition, transform.position - cameraPosition, out hit, 30f)) {
            Debug.DrawRay(cameraPosition, (transform.position - cameraPosition)* hit.distance, Color.green);
            Debug.Log("Grow!");
        } else {
            Debug.DrawRay(cameraPosition, (transform.position - cameraPosition)* 100, Color.red);
        }
    }

    public void MakeShrink() {

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
