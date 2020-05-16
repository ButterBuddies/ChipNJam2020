using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] Text scoreText;
    int score = 0;

    private void Start()
    {
        UpdateScore();
    }

    public void IncrementScore(int amount)
    {
        score += amount;
        UpdateScore();
    }

    public void DecrementScore(int amount)
    {
        if ((score -= amount) < 0)
            score = 0;
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

}
