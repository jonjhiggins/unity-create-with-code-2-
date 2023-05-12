using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private bool gameOver = false;
    private SpeedManager speedManager;


    void Start()
    {
        speedManager = GameObject.Find("SpeedManager").GetComponent<SpeedManager>();
        InvokeRepeating("ShowAndIncreaseScore", 0.1f, 0.1f);
    }

    void ShowAndIncreaseScore()
    {
        if (gameOver)
        {
            return;
        }
        score += speedManager.GetSpeed();
        Debug.Log($"Score: {score}");
    }

    public void SetGameOver()
    {
        gameOver = true;
    }
}
