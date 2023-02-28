using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformForPuzzle : MovingPlatformsMultiplePoints
{
    private const int positionToMove = 0;
    private const int numberOfPositions = 1;
    public PuzzleButton button;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        shouldMove = button.isbuttonPressed();
    }
}
