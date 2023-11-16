using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static MainManager Instance;

    public int numberOfPlayers;

    private float sceneDelayTime = 0.25f;
    private float currentTime;
    private float timeOfFall;

    private bool sceneExitInProgress;

    public string nextSceneName;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        sceneExitInProgress = false;
        nextSceneName = "";
    }

    private void Update()
    {
        if(sceneExitInProgress)
        {
            // print(timeOfFall + sceneDelayTime + " < " +Time.time);
            if(timeOfFall + sceneDelayTime < Time.time )
            {
                sceneExitInProgress = false;
                SceneManager.LoadScene(nextSceneName);
                nextSceneName = "";
            }
        }
    }

    public void playerHasFallen(GameObject losingPlayer)
    {
        loadNextScene();
    }

    public void loadNextScene()
    {

        if(nextSceneName != "")
        {
            print("NSN:"+nextSceneName);
            SceneManager.LoadScene(nextSceneName);
            nextSceneName = "";

        } else
        {
            string activeSceneName = SceneManager.GetActiveScene().name;

            switch(activeSceneName)
            {
                case "TestSceneA":
                    loadSceneOnDelay("TestSceneB");
                    break;

                case "TestSceneB":
                    loadSceneOnDelay("TestSceneC");
                    break;

                case "TestSceneC":
                    loadSceneOnDelay("TestSceneD");
                    break;

                case "TestSceneD":
                    loadSceneOnDelay("MainMenu");
                    break;
                
                default:
                    loadSceneOnDelay("MainMenu");
                    break;
            }
        }
    }

    public void loadSceneOnDelay(string SceneName)
    {
        print("Load "+ SceneName);

        if(GameObject.Find("ExitFooter").TryGetComponent<headerFooterScrollScript>(out headerFooterScrollScript HFSS))
        {
            HFSS.isMoving = true;
        }
        nextSceneName = SceneName;
        timeOfFall = Time.time;
        sceneExitInProgress = true;
    }
}

