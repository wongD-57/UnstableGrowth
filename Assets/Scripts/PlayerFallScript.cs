using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {        
            GameObject GOHolder = other.gameObject;

            MainManager.Instance.playerHasFallen(GOHolder);
            // MainManager.Instance.LoadSceneByName("TestSceneA");

            GameObject closeBanner = GameObject.Find("ExitFooter");
            if(closeBanner.TryGetComponent<headerFooterScrollScript>(
                out headerFooterScrollScript HFSS))
            {
                HFSS.isMoving = true;
            }
        }
    }
}
