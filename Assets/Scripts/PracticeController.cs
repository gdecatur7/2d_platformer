using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PracticeController : MonoBehaviour
{
    protected float speed = 3;
    protected Rigidbody2D rb2D;

    public HeartsUI heartsUI;
    protected int lives;

    //public Vector3 boxSize;
    //public float maxDistance;
    

    protected KeyCode upKey;
    protected KeyCode downKey;
    protected KeyCode rightKey;
    protected KeyCode leftKey;
    // any other action keys

    public bool grounded = false;

    [Header("Grounding")]
    public LayerMask groundMask;
    public float groundRayLength = 0.1f;
    public float groundRaySpread = 0.4f;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        upKey = KeyCode.UpArrow;
        downKey = KeyCode.DownArrow;
        rightKey = KeyCode.RightArrow;
        leftKey = KeyCode.LeftArrow;
        grounded = true;
    }

    // Update is called once per frame
    protected void Update()
    {
        float movementHorizontal = 0;
        float movementVertical = 0;

        if (Input.GetKey(upKey)) // jump
        {
            //grounded = false;
            movementVertical = speed;
        }
        if (Input.GetKey(downKey)) // crouch
        {
            //grounded = true;
            //movementVertical = -speed;
        }
        if (Input.GetKey(rightKey))
        {
            //grounded = true;
            movementHorizontal = speed;
            //mySpriteRenderer.sprite = moveAnimation[2];
            //mySpriteRenderer.flipX = false;
        }
        if (Input.GetKey(leftKey))
        {
            //grounded = true;
            movementHorizontal = -speed;
            //mySpriteRenderer.sprite = moveAnimation[2];
            //mySpriteRenderer.flipX = true;
        }

        //isGrounded();
        UpdateGrounding();

        Vector2 input = new Vector2(movementHorizontal, movementVertical);
        rb2D.velocity = input;
    }

    void UpdateGrounding()
    {
        Vector3 rayStart = transform.position + Vector3.up * groundRayLength;
        //Vector3 rayStartLeft = transform.position + Vector3.up * groundRayLength + Vector3.left * groundRaySpread;
        //Vector3 rayStartRight = transform.position + Vector3.up * groundRayLength + Vector3.right * groundRaySpread;

        RaycastHit2D hit = Physics2D.Raycast(rayStart, Vector3.down, groundRayLength * 2, groundMask);
        //RaycastHit2D hitLeft = Physics2D.Raycast(rayStartLeft, Vector3.down, groundRayLength * 2, groundMask);
        //RaycastHit2D hitRight = Physics2D.Raycast(rayStartRight, Vector3.down, groundRayLength * 2, groundMask);

        if (hit.collider != null ) //|| hitLeft.collider != null || hitRight.collider != null)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    void TakeDamage()
    {
        lives--;
        if (lives <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        HeartsUI.RemoveHeart(); // although this is called, all 3 hearts appear when level is reloaded
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            TakeDamage();
        }
    }
}
