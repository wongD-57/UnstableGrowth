using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static MainManager Instance;

    public int numberOfPlayers;

    public int pointsRequiredToWin = 5;

    int numberOfLevelsPlayed = 0;

    public int bluePoints;
    public int orangePoints;

    public int numberOfLevels  = 5;

    private float sceneDelayTime = 0.25f;
    private float currentTime;
    private float timeOfFall;

    private List<int> levelsChosen = new List<int>();

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
        if (losingPlayer.tag == "Blue")
        {
            
            orangePoints+=1;
        } else if (losingPlayer.tag == "Orange")
        {
            bluePoints+=1;
        }
        print("The score is B:"+bluePoints+" O:"+orangePoints);
        loadNextScene();
    }

    public void loadNextScene()
    {
        print("D");

        if (levelsChosen.Count <= 0)
        {
            print("D1");
            loadSceneOnDelay("MainMenu");
        } 
        else 
        {
            print("D2");
            string activeSceneName = SceneManager.GetActiveScene().name;

            if(activeSceneName != "MainMenu")
            {
                numberOfLevelsPlayed +=1;
            }

            if (bluePoints+orangePoints >= pointsRequiredToWin)
            {

                endGame();
            }

        }
    }

    public void endGame()
    {
        string winner = "nobody";
        if(bluePoints>orangePoints)
        {
            winner = "blue";
            loadSceneOnDelay("EndingScene_Blue");
        }

        if(bluePoints<orangePoints)
        {
            winner = "orange";
            loadSceneOnDelay("EndingScene_Orange");
        } 

        print("Score is "+bluePoints+" to "+orangePoints+". "+winner+" wins!");
        
        // loadSceneOnDelay("MainMenu");

        
    }

    public void startNewGame(int numberOfPlayers)
    {
        print("B");
        initialiseNewGame(numberOfPlayers);
        loadNextScene();
    } 

    public void loadSceneOnDelay(string SceneName)
    {
        if(GameObject.Find("ExitFooter").TryGetComponent<headerFooterScrollScript>(out headerFooterScrollScript HFSS))
        {
            HFSS.isMoving = true;
        }
        nextSceneName = SceneName;
        timeOfFall = Time.time;
        sceneExitInProgress = true;
    }

    void initialiseNewGame(int numberOfPlayers)
    {
        levelsChosen = new List<int>();

        for(int i = 0 ; i < numberOfLevels; i++)
        {
            int holder = Random.Range(0,9);
            levelsChosen.Add(holder);
        }

        numberOfLevelsPlayed = 0;
        bluePoints = 0;
        orangePoints = 0;
        print("The score is reset to B:"+bluePoints+" O:"+orangePoints);
    }

}

