using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public Button startButton;
    public string clipType;
    
    //public void Start()
    //{
    //    startButton.onClick.AddListener(() => LoadScene("GraceTile"));
    //    startButton.onClick.AddListener(delegate { LoadScene("GraceTile"); });
    //}
    public void Start()
    {
        if (clipType == "viking")
        {
            AudioManager.Instance.PlayVikingMusic();
        }
        else if (clipType == "chaotic")
        {
            AudioManager.Instance.PlayChaoticMusic();
        }
        else
        {
            AudioManager.Instance.PlaySuccessMusic();
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
