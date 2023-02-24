using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerControllerBase : MonoBehaviour
{
    public Sprite[] moveAnimation;
    public Sprite[] idleAnimation;
    public SpriteRenderer mySpriteRenderer;

    public float speed;
    public float jumpForce;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;

    //Action keys
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode leftKey;



    public LayerMask groundLayer;


    private Vector2 input;
    private bool shouldJump;
    private float isGrounded;

    protected Rigidbody2D rb2D;
    protected float offScreenVal; //TODO

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    protected void Update()
    {
        float movementHorizontal = 0;
        float movementVertical = rb2D.velocity.y;
        shouldJump = false;

        if (Input.GetKey(upKey)) // jump
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

        Debug.Log(shouldJump);
        if (shouldJump && IsGrounded()){
            Debug.Log("HEllo");
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


    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction,
            distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        Debug.DrawRay(position, direction, Color.green);

        return false;
    }

}
