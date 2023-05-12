using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public bool IsDashing { get; set; }
    public bool GameOver { get; set; }
    public bool PlayerReady { get; set; }
    private float _normalSpeed
    {
        get => PlayerReady ? 30 : 0;
    }
    public float Speed
    {
        get => IsDashing ? _normalSpeed * 2 : _normalSpeed;
    }
    private int _score;

    void Start()
    {
        InvokeRepeating("ShowAndIncreaseScore", 0.1f, 0.1f);
    }

    void ShowAndIncreaseScore()
    {
        if (GameOver || !PlayerReady)
        {
            return;
        }
        _score += IsDashing ? 2 : 1;
        Debug.Log($"Score: {_score}");
    }
}
