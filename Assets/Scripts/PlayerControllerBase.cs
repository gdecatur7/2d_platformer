using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerControllerBase : MonoBehaviour
{
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
    private Animator2D animation;

    protected Rigidbody2D rb2D;
    protected float offScreenVal; //TODO

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator2D>();
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
        }
        if (Input.GetKey(downKey)) // crouch
        {

        }
        if (Input.GetKey(rightKey))
        {
            movementHorizontal = 1 * speed;

        }
        if (Input.GetKey(leftKey))
        {
            movementHorizontal = -1 * speed;
        }

        input = new Vector2(movementHorizontal, movementVertical);
    }


    void FixedUpdate()
    {

        rb2D.velocity = input;

        if (shouldJump && IsGrounded()){
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


    public bool IsGrounded()
    {
        float reducePosition = (float)0.28;
        float distance = 1.0f;
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;

        if (animation.isPlayerFlipped())
        {
            reducePosition = -reducePosition;
        }
        position.x -= reducePosition;


        RaycastHit2D hit = Physics2D.Raycast(position, direction,
            distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        Debug.DrawRay(position, direction * 1, Color.green);


        return false;
    }

}
