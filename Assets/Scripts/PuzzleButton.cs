using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    private Collider2D col2d;
    private bool buttonPressed;
    // Start is called before the first frame update
    void Start()
    {
        col2d = GetComponent<Collider2D>();
        buttonPressed = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            buttonPressed = true;
        }
    }

    public bool isbuttonPressed()
    {
        return buttonPressed;
    }
}
