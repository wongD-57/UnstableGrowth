using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{

    // public Scene targetScene;
    public void changeScene(string sceneName)
    {        
        SceneManager.LoadScene(sceneName);
    }

    public void MainMenuSceneLoad()
    {        
        SceneManager.LoadScene("MainMenu");
    }

}
