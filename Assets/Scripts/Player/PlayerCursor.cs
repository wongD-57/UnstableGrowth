using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursor : MonoBehaviour
{

    public float cursorSpeed = 0.1f;
    public float xInputValue, yInputValue;
    private float platformZDatum;


    Vector2 input = Vector2.zero;

    public float cursorSpeedProportional = 0.1f; // Proportional Speed of Cursor relative to screen size

    //RectTransform m_rTransform;
    private GameObject cameraObject;

    Vector3 cameraPosition;

    private GameObject hitObject;

    public float cubeScaleSpeed = 0.1f;

    private List<GameObject> selectedObject = new List<GameObject>();

    void Start()
    {
        //m_rTransform = GetComponent<RectTransform>();

        GameObject GOHolder = GameObject.Find("PlatformParent");
        platformZDatum = GOHolder.transform.position.z;
        transform.position = new Vector3(transform.position.x,transform.position.y,platformZDatum-2);

        // transform.position += new Vector3((xInputValue, yInputValue, 0))*cursorSpeed;
        cameraObject = GameObject.Find("Main Camera");

        xInputValue = 0;
        yInputValue = 0;
    }

    void Update() {
        //m_rTransform.anchoredPosition += new Vector2(input.x * cursorSpeedProportional, input.y * cursorSpeedProportional);
        // transform.position += new Vector3(input.x * cursorSpeedProportional, input.y * cursorSpeedProportional, 0);

        movementManager();

        changeScale();
    }

    void OnTriggerEnter(Collider other)
    {
        print("YEAH!");
        print(other);
        selectedObject.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        print("YEAH!");
        print(other);
        GameObject GOHolder = other.gameObject;
        if(selectedObject.Contains(GOHolder))
        {
            print("Removed Object");
            selectedObject.Remove(other.gameObject);
        }
    }


    void changeScale()
    {
        // OverlapCollider
    }

    public void ReadInput(Vector2 inputCursor) {
        input = inputCursor;
    }

    public void MakeGrow() {
        RaycastHit hit;
        cameraPosition = cameraObject.transform.position;
        if (Physics.Raycast(cameraPosition, transform.position - cameraPosition, out hit, 30f)) {
            Debug.DrawRay(cameraPosition, (transform.position - cameraPosition)* hit.distance, Color.green);
            Debug.Log("Grow!");
            if (hit.rigidbody.gameObject.GetComponent<BoxScale>() != null) {
                hit.rigidbody.gameObject.GetComponent<BoxScale>().MakeGrow();
            }
        } else {
            Debug.DrawRay(cameraPosition, (transform.position - cameraPosition)* 100, Color.red);
        }
    }

    public void MakeShrink() {
        RaycastHit hit;
        cameraPosition = cameraObject.transform.position;
        if (Physics.Raycast(cameraPosition, transform.position - cameraPosition, out hit, 30f)) {
            Debug.DrawRay(cameraPosition, (transform.position - cameraPosition)* hit.distance, Color.green);
            Debug.Log("Shrink!");
            if (hit.rigidbody.gameObject.GetComponent<BoxScale>() != null) {
                hit.rigidbody.gameObject.GetComponent<BoxScale>().MakeShrink();
            }
        } else {
            Debug.DrawRay(cameraPosition, (transform.position - cameraPosition)* 100, Color.red);
        }
    }


    public void movementManager(){
        transform.position += new Vector3(xInputValue, yInputValue, 0)*cursorSpeed*Time.deltaTime;
    }
}
