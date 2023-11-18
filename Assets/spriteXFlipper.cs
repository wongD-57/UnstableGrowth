using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteXFlipper : MonoBehaviour
{
        // Start is called before the first frame update

    public GameObject Container;
    public armDirectionScript ADScript;

    public float distbuffer = 0.5f;

    private float lastFrameUpdate;
    // Update is called once per frame

    void Start()
    {
        lastFrameUpdate = transform.position.x;
    }
    void Update()
    {
        float i = lastFrameUpdate - transform.position.x;
        // print(lastFrameUpdate +" - "+transform.position.x+" = "+ i);
        if (i < -distbuffer)
        {
            print("Case A");
            lastFrameUpdate = transform.position.x;
            faceRight();
        }else if (i> distbuffer)
        {
            print("Case B");
            lastFrameUpdate = transform.position.x;
            faceLeft();

        }
    }

    void faceLeft()
    {
        float flippedXScale = Mathf.Abs(Container.transform.localScale[0])*-1;
        Container.transform.localScale = new Vector3(flippedXScale,Container.transform.localScale[1],Container.transform.localScale[2]);
        ADScript.flipper = -1;
    }

    void faceRight()
    {
        float flippedXScale = Mathf.Abs(Container.transform.localScale[0]);
        Container.transform.localScale = new Vector3(flippedXScale,Container.transform.localScale[1],Container.transform.localScale[2]);
        ADScript.flipper = 1;
    }
}
