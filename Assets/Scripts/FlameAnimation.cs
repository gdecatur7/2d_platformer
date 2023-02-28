using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAnimation : MonoBehaviour
{
    public Sprite[] flameAnim;
    public SpriteRenderer sr;
    private int index;

    public float animationFPS;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 1 / animationFPS;
            sr.sprite = flameAnim[index % flameAnim.Length];
            index++;
        }
    }
}
