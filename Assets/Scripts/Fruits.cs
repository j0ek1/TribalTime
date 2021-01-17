using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fruits : MonoBehaviour
{
    public SceneControl0 sceneCont0;
    public SceneControl1 sceneCont1;
    private Scene currentScene;

    void Start()
    {
        sceneCont0 = GameObject.Find("SceneControl").GetComponent<SceneControl0>();
        sceneCont1 = GameObject.Find("SceneControl").GetComponent<SceneControl1>();
        currentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") //If fruits collide with player
        {
            AudioManager.PlaySound("fruitPickup");
            if (currentScene.buildIndex == 1)
            {
                sceneCont0.collectedFruits++;
            }
            if (currentScene.buildIndex == 2)
            {
                sceneCont1.collectedFruits++;
            }
            Destroy(gameObject);
        }
    }
}
