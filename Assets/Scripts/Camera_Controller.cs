using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Transform playerFollow;
    public Transform playerFollowSecond;
    public float offset;
    public float offsetSmoothing;
    private Transform playerPositionToFollow;
    private Vector3 positionForCameraTofollow;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void LateUpdate()
    {
        followLowerPlayer();

        positionForCameraTofollow = new Vector3(transform.position.x,
            playerPositionToFollow.position.y, transform.position.z);

        if (playerPositionToFollow.localScale.y > 0f)
        {
            positionForCameraTofollow = new
                Vector3(positionForCameraTofollow.x,
                positionForCameraTofollow.y + offset,
                positionForCameraTofollow.z);
        }
        else
        {
            positionForCameraTofollow = new
                    Vector3(positionForCameraTofollow.x,
                positionForCameraTofollow.y - offset,
                positionForCameraTofollow.z);
        }

        transform.position = Vector3.Lerp(transform.position,
            positionForCameraTofollow, offsetSmoothing * Time.deltaTime);
    }

    void followLowerPlayer()
    {
        if (playerFollow.position.y < playerFollowSecond.position.y)
        {
            playerPositionToFollow = playerFollow;
        } else
        {
            playerPositionToFollow = playerFollowSecond;
        }
        
    }
}
