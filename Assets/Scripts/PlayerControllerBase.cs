using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBase : MonoBehaviour
{
    public Sprite[] walkAnimation;
    public Sprite[] idleAnimation;
    public SpriteRenderer mySpriteRenderer;

    public float speed;
    protected Rigidbody2D rb2D;

    protected KeyCode upKey;
    protected KeyCode downKey;
    protected KeyCode rightKey;
    protected KeyCode leftKey;
    // any other action keys

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
        float movementVertical = 0;

        if (Input.GetKey(upKey))
        {
            movementVertical = speed;
            mySpriteRenderer.sprite = walkAnimation[0];
        }
        if (Input.GetKey(downKey))
        {
            movementVertical = -speed;
            mySpriteRenderer.sprite = walkAnimation[1];
        }
        if (Input.GetKey(rightKey))
        {
            movementHorizontal = speed;
            mySpriteRenderer.sprite = walkAnimation[2];
            mySpriteRenderer.flipX = false;
        }
        if (Input.GetKey(leftKey))
        {
            movementHorizontal = -speed;
            mySpriteRenderer.sprite = walkAnimation[2];
            mySpriteRenderer.flipX = true;
        }

        Vector2 input = new Vector2(movementHorizontal, movementVertical);
        rb2D.velocity = input;
    }
}
