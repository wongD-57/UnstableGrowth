using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUIScript : MonoBehaviour
{
    
    private MainManager MMScript;

    public TMP_Text blueTextGO;
    public TMP_Text orangeTextGO;

    public 
    // Start is called before the first frame update
    void Start()
    {
        GameObject MMGO = GameObject.Find("MainManagerObject");

        print("Score Script Started");

        if(MMGO.TryGetComponent<MainManager>(out MMScript))
        {
            blueTextGO.text = MMScript.bluePoints.ToString();
            orangeTextGO.text = MMScript.orangePoints.ToString();

             
        } else
        {
            blueTextGO.text = "err";
            orangeTextGO.text = "err";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
