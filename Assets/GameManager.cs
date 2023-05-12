using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public bool IsDashing { get; set; }
    public bool GameOver { get; set; }
    private float normalSpeed = 30;
    public float Speed
    {
        get => IsDashing ? normalSpeed * 2 : normalSpeed;
    }
    private int score;

    void Start()
    {
        InvokeRepeating("ShowAndIncreaseScore", 0.1f, 0.1f);
    }

    void ShowAndIncreaseScore()
    {
        if (GameOver)
        {
            return;
        }
        score += IsDashing ? 2 : 1;
        Debug.Log($"Score: {score}");
    }
}
