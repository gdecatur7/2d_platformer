using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{

    public GameObject pauseMenu;
    public string MainMenuScene;
    public string levelToSkip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                unpause();
            } else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
          
        }
    }

    public void unpause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void skipLevel()
    {
        SceneManager.LoadScene(levelToSkip);
        Time.timeScale = 1f;
    }

    public void exitToMenu()
    {
        SceneManager.LoadScene(MainMenuScene);
        Time.timeScale = 1f;
    }
}
