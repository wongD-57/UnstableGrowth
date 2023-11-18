using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{

    public AudioSource backgroundMusic;
    // Start is called before the first frame update

    void Start()
    {
        PlayBackgroundMusic();
        print("Playing Music");
    }

    public void PlayBackgroundMusic()
    {
        backgroundMusic.Play();
    }
}
