using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{

    public GameObject pauseMenu;
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
        Debug.Log("HELLO");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
