using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallScript : MonoBehaviour
{

     

    void OnTriggerEnter(Collider other)
    {
        print(other.name);

        if(other.tag == "Player")
        {        
            print("ROUND OVER");
            GameObject closeBanner = GameObject.Find("ExitFooter");
            if(closeBanner.TryGetComponent<headerFooterScrollScript>(out headerFooterScrollScript HFSS))
            {
                print("FOUND");
                HFSS.isMoving = true;
            } else
            {
                print("Not found");
            }
        }
    }
}
