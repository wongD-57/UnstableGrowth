using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButtonsScript : MonoBehaviour
{
    // Update is called once per frame
    public void TwoPlayerStart()
    {
        GameObject GOHolder = GameObject.Find("MainManagerObject");
        MainManager MMScript = GOHolder.GetComponent<MainManager>();
        MMScript.startNewGame(2);
    }

    public void OnePlayerStart()
    {
        GameObject GOHolder = GameObject.Find("MainManagerObject");
        MainManager MMScript = GOHolder.GetComponent<MainManager>();
        MMScript.startNewGame(1);
    }
}
