using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallScript : MonoBehaviour
{
    private headerFooterScrollScript HFSS;
    private GameObject closeBanner;

    private bool sensing;

    void Start()
    {
        closeBanner = GameObject.Find("ExitFooter");
        sensing = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if(sensing)
        {

            GameObject GOHolder = other.gameObject;
            switch(other.tag)
            {   
                case "Blue":

                    if(closeBanner.TryGetComponent<headerFooterScrollScript>(
                        out HFSS))
                    {
                        HFSS.isMoving = true;
                    }
                    MainManager.Instance.playerHasFallen(GOHolder);
                    sensing = false;
                    break;

                case "Orange":

                    if(closeBanner.TryGetComponent<headerFooterScrollScript>(
                        out HFSS))
                    {
                        HFSS.isMoving = true;
                    }
                    MainManager.Instance.playerHasFallen(GOHolder);
                    sensing = false;
                    break;

            
            } 
        }
    }
}
