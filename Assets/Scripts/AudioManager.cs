using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioClip vikingMusic;
    public AudioClip chaoticMusic;
    public AudioClip successMusic;
    public static AudioManager Instance = null;
    private string clipName;
    
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
        if (clipName == "viking" )
        {
            return;
        }
        backgroundMusic.clip = vikingMusic;
        clipName = "viking";
        backgroundMusic.Play();
    }
    public void PlayChaoticMusic()
    {
        if (clipName == "chaotic")
        {
            return;
        }
        backgroundMusic.clip = chaoticMusic;
        clipName = "chaotic";
        backgroundMusic.Play();
    }
    public void PlaySuccessMusic()
    {
        if (clipName == "success")
        {
            return;
        }
        backgroundMusic.clip = successMusic;
        clipName = "success";
        backgroundMusic.Play();
    }
}
