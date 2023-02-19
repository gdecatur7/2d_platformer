using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : PlayerControllerBase
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        upKey = KeyCode.W;
        downKey = KeyCode.S;
        rightKey = KeyCode.D;
        leftKey = KeyCode.A;
        // any other keys
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
