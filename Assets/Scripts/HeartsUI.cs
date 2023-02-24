using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsUI : MonoBehaviour
{
    public Image[] hearts;
    private int heartsVisible;

    private static HeartsUI instance;
    
    void Start()
    {
        instance = this;
        heartsVisible = hearts.Length;
    }

    public static void RemoveHeart()
    {
        instance._RemoveHeart();
    }

    private void _RemoveHeart()
    {
        heartsVisible--;
        if (heartsVisible >= 0)
        {
            hearts[heartsVisible].enabled = false;
        }
    }
}
