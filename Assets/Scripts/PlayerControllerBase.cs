using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerControllerBase : MonoBehaviour
{
    public Animator2D animator;
    public float speed;
    public float jumpForce;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;
    public float invulnerabilityTime = 2;
    public AudioSource audioSource;
    public AudioClip jump;
    public AudioClip damage;
    public AudioClip death;

    //Action keys
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode leftKey;

    public LayerMask groundLayer;



    private Vector2 input;
    private float isGrounded;

    private int lives = 3;
    private bool invulnerable = false;
    private bool isDying = false;
    public SpriteRenderer sRenderer;

    protected Rigidbody2D rb2D;
    protected float offScreenVal; //TODO delete??

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        audioSource = gameObject.GetComponent<AudioSource>();
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
        
        float distance = 1.0f;
        float playerRadius = 0.49f;
            //(sRenderer.sprite.bounds.size.x / 2);
        
        Vector2 positionSide1 = new Vector2(transform.position.x + playerRadius, transform.position.y);
        Vector2 positionSide2 = new Vector2(transform.position.x - playerRadius, transform.position.y);
        Vector2 direction = Vector2.down;
        

        
       

        RaycastHit2D hit1 = Physics2D.Raycast(positionSide1, direction,
            distance, groundLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(positionSide2, direction,
            distance, groundLayer);
        if (hit1.collider != null || hit2.collider != null)
        {
            return true;
        }
        Debug.DrawRay(positionSide1, direction * 1, Color.green);


        return false;
    }

    /**
     * handleMovement - Function for handling basic movement of character
     */
    private void handleMovement()
    {
        if (isDying)
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            return;
        }
        if (Input.GetKeyDown(upKey)) // jump
        {
            if (IsGrounded())
            {
                rb2D.AddForce(Vector2.up * jumpForce * 1, ForceMode2D.Impulse);
                audioSource.time = 0.2f;
                audioSource.PlayOneShot(jump);

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
        
        lives--;
        HeartsUI.RemoveHeart();
        if (lives <= 0)
        {
            StartCoroutine(DeathAnimation(2)); // coroutine not working

        }
        else
        {
            audioSource.PlayOneShot(damage);
        }

            StartCoroutine(Invulnerability(invulnerabilityTime));

        
    }

    IEnumerator DeathAnimation(float time)
    {

        isDying = true;
        audioSource.PlayOneShot(death);
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
    public bool getDying()
    {
        return isDying;
    }
    public void setDying()
    {
        isDying = true;
        StartCoroutine(DeathAnimation(2));
    }

}
