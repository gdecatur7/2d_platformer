using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioClip vikingMusic;
    public AudioClip chaoticMusic;
    public static AudioManager Instance = null;
    private bool playingViking = false;
    private bool playingChaotic = false;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
      
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlayVikingMusic()
    {
        if (playingViking)
        {
            return;
        }
        backgroundMusic.clip = vikingMusic;
        backgroundMusic.Play();
        playingViking = true;
        playingChaotic = false;
    }
    public void PlayChaoticMusic()
    {
        if (playingChaotic)
        {
            return;
        }
        backgroundMusic.clip = chaoticMusic;
        backgroundMusic.Play();
        playingChaotic = true;
        playingViking = false;
    }
}
