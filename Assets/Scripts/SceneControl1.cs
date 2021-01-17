using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl1 : MonoBehaviour
{
    public PlayerControls player;
    public ProcGen1 procGen;
    public float time;
    public TextMeshProUGUI tmpTime;
    private string currentTime;
    public int collectedFruits;
    public Score score;

    void Start()
    {
        collectedFruits = 0;       
    }

    void Update()
    {
        time -= Time.deltaTime; //Countdown timer
        currentTime = time.ToString("F2"); //Converting timer to string with 2 decimal places to be displayed
        SetCurrentTime(currentTime);

        if (player.playerX > 8.5 && procGen.fruitCounter == collectedFruits) //Handles changing levels
        {
            score.IncreaseScore();
            SceneManager.LoadScene("Level0");
        }

        if (time < 0f || player.playerX < -9.5f) //If the player runs out of time or goes out of bounds
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void SetCurrentTime(string currentTime) //Displaying the timer
    {
        tmpTime.SetText($"TIME: {currentTime}");
    }
}
