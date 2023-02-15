using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : PlayerControllerBase
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        upKey = KeyCode.UpArrow;
        downKey = KeyCode.DownArrow;
        rightKey = KeyCode.RightArrow;
        leftKey = KeyCode.LeftArrow;
        // any other keys
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
