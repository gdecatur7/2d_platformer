using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doorway : MonoBehaviour
{
    public bool isPlayerHere;

    void Start()
    {
        isPlayerHere = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            isPlayerHere = true;
            collision.gameObject.SetActive(false);
        }

        Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
    }
}
