using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformsMultiplePoints : MovingPlatformAbstract
{
    private int nextIndex = 0;
    private float pauseTimer;
    public float pauseAtPatrolPoint = 0.0f;
    public bool shouldMove;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        patrolPositions = new Vector3[patrolPoints.Length];
        for (int i = 0; i < patrolPoints.Length; i++)
        {
            patrolPositions[i] = patrolPoints[i].position;
            Destroy(patrolPoints[i].gameObject);
        }
        patrolPoints = new Transform[0];
    }

    protected override void performMovement()
    {
        if (shouldMove)
        {
            Vector2 toTarget = patrolPositions[nextIndex] - transform.position;
            Vector2 toPreviousTarget = patrolPositions[(nextIndex - 1 +
                patrolPositions.Length) % patrolPositions.Length] -
                transform.position;
            if (toTarget.magnitude <= speed * Time.fixedDeltaTime)
            {
                nextIndex++;
                nextIndex %= patrolPositions.Length;
                pauseTimer = pauseAtPatrolPoint;
            }

            float distance1 = toTarget.magnitude;
            float distance2 = toPreviousTarget.magnitude;
            float acceleration = Mathf.Clamp(Mathf.Min(distance1, distance2),
                0.1f, 1.0f);

            toTarget.Normalize();
            if (accelerate)
            {
                toTarget *= acceleration;
            }

            pauseTimer -= Time.deltaTime;
            if (pauseTimer <= 0.0f)
            {
                rb2d.velocity = toTarget * speed;
            }
            else
            {
                rb2d.velocity = Vector2.zero;
            }
        }

    }
}
