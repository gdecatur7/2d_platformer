using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb2d;
    Collider2D col2d;
    public float spikeSpeed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        col2d = GetComponent<Collider2D>();
        rb2d.velocity = new Vector2(0, 1) * spikeSpeed;
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnCollisionEnter2D(Collision2D col2d)
    {

        if (col2d.collider.tag != "Player")
        {
            Physics2D.IgnoreCollision(col2d.collider, col2d.otherCollider);
        } else
        {
            Debug.Log("HELLO");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
