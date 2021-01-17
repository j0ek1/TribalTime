using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        AudioManager.PlaySound("menuButton");
        SceneManager.LoadScene("Level0");
    }
    public void Instructions()
    {
        AudioManager.PlaySound("menuButton");
    }

    public void Quit()
    {
        AudioManager.PlaySound("menuButton");
        Application.Quit();
    }

    public void Title()
    {
        AudioManager.PlaySound("menuButton");
        SceneManager.LoadScene("TitleScreen");
    }
}
