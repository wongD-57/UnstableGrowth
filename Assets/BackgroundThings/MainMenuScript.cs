using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{

    public GameObject OptionsMenu;
    public GameObject PlayMenu;

    void Start()
    {
        PlayMenu.SetActive(false);
        OptionsMenu.SetActive(false);
    }

    public void StartGameButton()
    {

        // print("SGB Pressed");
        // print(OptionsMenu.activeSelf);
        if(!PlayMenu.activeSelf){
            PlayMenu.SetActive(true);
        } else
        {
            PlayMenu.SetActive(false);
        }
    }

    public void OptionsButton()
    {
        // print("OB Pressed");
        if(!OptionsMenu.activeSelf){
            OptionsMenu.SetActive(true);
        } else
        {
            OptionsMenu.SetActive(false);
        }
    }

}
