using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller2D : MonoBehaviour
{
    public float speed;
    public bool grounded;
    public LayerMask groundLayers;
    public float groundRayLength = 0.1f;
    public float groundRaySpread = 0.1f;
    [HideInInspector] public Vector2 relativeVelocity = new Vector2();

    protected Rigidbody2D rb2d;
    //protected MovingPlatform onMovingPlatform;

    public virtual void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    protected bool UpdateGrounding()
    {
        Vector3 rayStart = transform.position + Vector3.up * groundRayLength;
        Vector3 rayStartLeft = transform.position + Vector3.up * groundRayLength + Vector3.left * groundRaySpread;
        Vector3 rayStartRight = transform.position + Vector3.up * groundRayLength + Vector3.right * groundRaySpread;

        RaycastHit2D hit = Physics2D.Raycast(rayStart, Vector2.down, groundRayLength * 2, groundLayers);
        RaycastHit2D hitLeft = Physics2D.Raycast(rayStartLeft, Vector2.down, groundRayLength * 2, groundLayers);
        RaycastHit2D hitRight = Physics2D.Raycast(rayStartRight, Vector2.down, groundRayLength * 2, groundLayers);

        Debug.DrawLine(rayStart, rayStart + Vector3.down * groundRayLength * 2, Color.red);
        Debug.DrawLine(rayStartLeft, rayStartLeft + Vector3.down * groundRayLength * 2, Color.red);
        Debug.DrawLine(rayStartRight, rayStartRight + Vector3.down * groundRayLength * 2, Color.red);
        if (hit.collider != null)
        {
            grounded = true;
            //onMovingPlatform = hit.collider.gameObject.GetComponent<MovingPlatform>();
            return true;
        }
        else if (hitLeft.collider != null)
        {
            grounded = true;
            //onMovingPlatform = hitLeft.collider.gameObject.GetComponent<MovingPlatform>();
            return true;
        }
        else if (hitRight.collider != null)
        {
            grounded = true;
            //onMovingPlatform = hitRight.collider.gameObject.GetComponent<MovingPlatform>();
            return true;
        }
        //onMovingPlatform = null;
        grounded = false;
        return false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Controller2D controller = collision.gameObject.GetComponent<Controller2D>();
        if(controller != null) {
            Vector3 impactDirection = collision.gameObject.transform.position - transform.position;
            Hurt(impactDirection);
        }
    }

    protected abstract void Hurt(Vector3 impactDirection);
}
