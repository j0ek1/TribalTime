using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    static public int score = 0; //Static variable handles score between multiple scenes
    static public int highscore = 0;
    public TextMeshProUGUI tmpScore;
    public TextMeshProUGUI tmpHighscore;

    void Start()
    {
        DisplayScore(score);
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            DisplayHighscore(highscore);
            score = 0;
        }
    }

    public void IncreaseScore() //Called when completing a level
    {
        score++;
        if (score > highscore)
        {
            highscore = score;
        }     
        DisplayScore(score);
    }

    void DisplayScore(int score)
    {
        tmpScore.SetText($"SCORE: {score}");
    }

    void DisplayHighscore(int highscore)
    {
        tmpHighscore.SetText($"HIGHSCORE: {highscore}");
    }
}
