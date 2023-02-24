using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator2D : MonoBehaviour
{
    public enum AnimationState
    {
        idle,
        walk,
        jump,
        walkRight,
        walkLeft
    }

    public float animationFPS;
    public Sprite[] idleAnimation;
    public Sprite[] walkAnimation;
    public Sprite[] jumpAnimation;
    public Sprite[] walkRightAnimation;
    public Sprite[] walkLeftAnimation;

    protected Rigidbody2D rb2D;
    //protected PlayerControllerBase controller;
    protected PlayerControllerBase controller;
    public SpriteRenderer mySpriteRenderer;

    protected float frameTimer = 0;
    protected int frameIndex = 0;
    public AnimationState state = AnimationState.idle;
    protected Dictionary<AnimationState, Sprite[]> animationAtlas;
    private bool flipped;

    // Start is called before the first frame update
    void Start()
    {
        animationAtlas = new Dictionary<AnimationState, Sprite[]>();
        animationAtlas.Add(AnimationState.idle, idleAnimation);
        animationAtlas.Add(AnimationState.walk, walkAnimation);
        animationAtlas.Add(AnimationState.jump, jumpAnimation);
        animationAtlas.Add(AnimationState.walkRight, walkRightAnimation);
        animationAtlas.Add(AnimationState.walkLeft, walkLeftAnimation);

        rb2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerControllerBase>();
        //controller = GetComponent<PlayerControllerBase>();
        flipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        AnimationState newState = GetAnimationState();
        if (state != newState)
        {
            TransitionToState(newState);
        }

        frameTimer -= Time.deltaTime;
        if (frameTimer <= 0.0f)
        {
            frameTimer = 1 / animationFPS;
            Sprite[] anim = animationAtlas[state];
            frameIndex %= anim.Length;
            mySpriteRenderer.sprite = anim[frameIndex];
            frameIndex++;
        }

        if (rb2D.velocity.x < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            flipped = true;
        }

        if (rb2D.velocity.x > 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
            flipped = false;

        }
    }

    void TransitionToState(AnimationState newState)
    {
        frameTimer = 0;
        frameIndex = 0;
        state = newState;
    }

    AnimationState GetAnimationState()
    {
        if (!controller.IsGrounded())
        {
            return AnimationState.jump;
        }
        if (Mathf.Abs(rb2D.velocity.x) > 0.1f)
        {
            return AnimationState.walk;
        }
        return AnimationState.idle;
    }

    public bool isPlayerFlipped()
    {
        return flipped;
    }
}
