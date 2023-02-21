using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerBase : MonoBehaviour
{
    public Sprite[] moveAnimation;
    public Sprite[] idleAnimation;
    public SpriteRenderer mySpriteRenderer;

    public float speed;
    public float jumpForce;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;
    protected Rigidbody2D rb2D;
    private Vector2 input;
    private bool shouldJump,canJump;

    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode leftKey;
    // any other action keys

    protected float offScreenVal; //TODO

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        canJump = false;
    }

    // Update is called once per frame
    protected void Update()
    {
        float movementHorizontal = 0;
        float movementVertical = rb2D.velocity.y;
        shouldJump = false;

        if (Input.GetKey(upKey) && canJump) // jump
        {
            shouldJump = true;
            //mySpriteRenderer.sprite = moveAnimation[0];
        }
        if (Input.GetKey(downKey)) // crouch
        {
            //movementVertical = -1 * speed;
            //mySpriteRenderer.sprite = moveAnimation[1];
        }
        if (Input.GetKey(rightKey))
        {
            movementHorizontal = 1 * speed;
            //mySpriteRenderer.sprite = moveAnimation[2];
            //mySpriteRenderer.flipX = false;
        }
        if (Input.GetKey(leftKey))
        {
            movementHorizontal = -1 * speed;
            //mySpriteRenderer.sprite = moveAnimation[2];
            //mySpriteRenderer.flipX = true;
        }

        input = new Vector2(movementHorizontal, movementVertical);
    }


    void FixedUpdate()
    {

        rb2D.velocity = input;

        if (shouldJump){
            rb2D.AddForce(Vector2.up * jumpForce * 1, ForceMode2D.Impulse);
        }

        if (rb2D.velocity.y < 0)
        {
            rb2D.gravityScale = fallingGravityScale;
        } else
        {
            rb2D.gravityScale = gravityScale;
        }

    }


    protected bool isOnScreen()
    {
        if (transform.position.y < offScreenVal)
        {
            return false;
        }

        return true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }
    }
}
