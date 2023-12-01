using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExitOnTimer : MonoBehaviour
{

    public float timeToExit;

    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > startTime+timeToExit)   
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
