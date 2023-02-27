using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnding : MonoBehaviour
{

    public Doorway doorOne;
    public Doorway doorTwo;
    public string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOne.isPlayerHere && doorTwo.isPlayerHere)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
