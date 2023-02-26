using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Transform playerFollow;
    public Transform playerFollowSecond;
    private float playerPositionToFollow;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        followLowerPlayer();
        Vector3 pos = transform.position;
        pos.y = playerPositionToFollow;
        transform.position = pos;
    }

    void followLowerPlayer()
    {
        playerPositionToFollow = Mathf.Min(playerFollow.position.y,
            playerFollowSecond.position.y);
    }
}
