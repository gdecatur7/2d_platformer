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

    public Sprite[] deathAnimation;

    private Vector2 input;
    private float isGrounded;
    private Animator2D animation;

    private int lives = 3;
    private bool invulnerable = false;
    public SpriteRenderer sRenderer;

    protected Rigidbody2D rb2D;
    protected float offScreenVal; //TODO delete??

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator2D>();
    }

    // Update is called once per frame
    protected void Update()
    {
        handleMovement();

    }

    // todo delete??
    protected bool isOnScreen()
    {
        if (transform.position.y < offScreenVal)
        {
            return false;
        }

        return true;
    }

    /**
     * isGrounded - Method for groundChecking of player character
     */
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

    /**
     * handleMovement - Function for handling basic movement of character
     */
    private void handleMovement()
    {

        if (Input.GetKeyDown(upKey)) // jump
        {
            if (IsGrounded())
            {
                rb2D.AddForce(Vector2.up * jumpForce * 1, ForceMode2D.Impulse);
            }
        }

        float movementHorizontal = 0;
        float movementVertical = rb2D.velocity.y;

        // Movement Left or right
        if (Input.GetKey(rightKey))
        {
            movementHorizontal = 1 * speed;

        }
        if (Input.GetKey(leftKey))
        {
            movementHorizontal = -1 * speed;
        }

        input = new Vector2(movementHorizontal, movementVertical);
        rb2D.velocity = input;

        if (rb2D.velocity.y < 0)
        {
            rb2D.gravityScale = fallingGravityScale;
        }
        else
        {
            rb2D.gravityScale = gravityScale;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Controller2D controller = collision.gameObject.GetComponent<Controller2D>();
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        if (invulnerable)
        {
            return;
        }
        //audioSource.PlayOneShot(hitsound);
        lives--;
        HeartsUI.RemoveHeart();
        if (lives <= 0)
        {
            StartCoroutine(DeathAnimation(2)); // coroutine not working
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        StartCoroutine(Invulnerability(1));
    }

    IEnumerator DeathAnimation(float time)
    {
        int dIndex = 0;
        for (int i = 0; i < time / 0.2f; i++)
        {
            if (dIndex < deathAnimation.Length)
            {
                sRenderer.sprite = deathAnimation[dIndex];
                dIndex++;
                yield return new WaitForSeconds(0.1f);
                sRenderer.sprite = deathAnimation[dIndex];
                dIndex++;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    IEnumerator Invulnerability(float time)
    {
        invulnerable = true;
        for (int i = 0; i < time / 0.2f; i++)
        {
            sRenderer.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            sRenderer.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
        invulnerable = false;
    }

}
