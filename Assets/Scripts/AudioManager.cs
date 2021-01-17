using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip menuButton, fruitPickup;
    static AudioSource audioSrc;

    void Start()
    {
        menuButton = Resources.Load<AudioClip>("menuButton");
        fruitPickup = Resources.Load<AudioClip>("fruitPickup");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "menuButton":
                audioSrc.PlayOneShot(menuButton);
                break;
            case "fruitPickup":
                audioSrc.PlayOneShot(fruitPickup);
                break;
        }
    }
}
