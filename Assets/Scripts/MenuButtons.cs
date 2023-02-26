using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public Button startButton;
    
    //public void Start()
    //{
    //    startButton.onClick.AddListener(() => LoadScene("GraceTile"));
    //    startButton.onClick.AddListener(delegate { LoadScene("GraceTile"); });
    //}

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
