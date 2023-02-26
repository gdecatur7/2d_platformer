using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipLevel : MonoBehaviour
{
    public int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.GetSceneAt(sceneIndex);
            //SceneManager.LoadScene("name");
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }
}
