using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingPlatformAbstract : MonoBehaviour
{
    public float speed = 5;
    public bool accelerate = true;
    public Transform[] patrolPoints;
    protected Vector3[] patrolPositions;

    [HideInInspector] public Rigidbody2D rb2d;


    virtual protected void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    virtual protected void Update()
    {
        performMovement();
    }

    abstract protected void performMovement();

    private void OnDrawGizmos()
    {
        if (patrolPoints.Length < 2) return;

        Color startColor = new Color(0.6f, 0.2f, 0.2f);
        Color endColor = new Color(1.0f, 0.0f, 0.0f);
        for (int i = 0; i < patrolPoints.Length; i++)
        {
            Gizmos.color =
                Color.Lerp(startColor, endColor, i / (float)patrolPoints.Length);
            Gizmos.DrawLine(patrolPoints[i].position,
                patrolPoints[(i + 1) % patrolPoints.Length].position);
            Gizmos.DrawWireSphere(patrolPoints[i].position,0.5f);
        }
    }
}
