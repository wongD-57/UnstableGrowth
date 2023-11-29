using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armDirectionScript : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject cursorObject;

    private float angleDifference;

    bool movingRight = true;
    bool movingRightChecker = true;

    public int flipper = 1;

    void Start() {
        cursorObject = transform.parent.parent.parent.GetChild(0).gameObject;
    }


    // Update is called once per frame
    void Update()
    {

        if(movingRight != movingRightChecker)
        {
            // changeDirection(movingRight);
        }

        Vector3 relativePos = transform.position - cursorObject.transform.position;

        Vector3 desiredUp = new Vector3(relativePos.y, -relativePos.x, 0);

        desiredUp *= flipper;
        // desiredUp *= -1;

        Quaternion targetRotation = Quaternion.LookRotation (Vector3.forward, desiredUp);   

        transform.rotation = targetRotation;
    }

    // public void changeDirection(bool movingRight)
    // {
    //     if(movingRight){
    //         flipper = 1;
    //     }else{
    //         flipper = -1;
    //     }
    // }
}
