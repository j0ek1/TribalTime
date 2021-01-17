using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcGen0 : MonoBehaviour
{
    public GameObject dirt; //Gameobjects for tileset
    public GameObject grass;
    public GameObject grassTop;
    public GameObject spike;
    public GameObject spikeTop;
    private int width = 19;
    private int height;
    private int heightTop;
    private int spikeChance;
    private int spikeChanceTop;
    private int spikeCount = 0;

    public GameObject banana;
    public GameObject pineapple;
    public GameObject strawberry;
    public GameObject cherries;
    private int fruitChance = 0;
    private int fruitChoice = 1;
    public int fruitCounter = 0;
    
    void Start()
    {
        Generation(); //Handles floor generation with fruits
        GenerationTop(); //Handles roof generation
    }

    void Generation()
    {
        fruitChoice = Random.Range(1, 5);
        for (int x = 0; x < width; x++) //Loops through width of screen
        {
            height = Random.Range(0, 4);
            for (int y = 0; y < height; y++) //Loops through height of floor
            {
                spawnObj(dirt, x, y);
            }
            spawnObj(grass, x, height);
            spikeChance = Random.Range(0, 2); //Random decision if spikes will spawn
            if (spikeChance == 1 && x != 1)
            {
                spikeCount++;
                if (spikeCount < 3) //Preventing spikes being in a row of 3
                {
                    spawnObj(spike, x, height + 1);
                }
            }
            else
            {
                spikeCount = 0;
                fruitChance = Random.Range(0, 2); //Random chance for a fruit to spawn
                if (fruitChance == 1 && fruitCounter < 5 && x != 0 && x != 1 && x != 18) //Ensures fruit doesnt spawn more than 4 times or on outer bounds
                {
                    switch (fruitChoice)
                    {
                        case 1:
                            spawnObj(banana, x, height + 1);
                            break;
                        case 2:
                            spawnObj(pineapple, x, height + 1);
                            break;
                        case 3:
                            spawnObj(strawberry, x, height + 1);
                            break;
                        case 4:
                            spawnObj(cherries, x, height + 1);
                            break;

                    }
                    fruitCounter++; //Counts number of fruits
                    fruitChoice++;
                    if (fruitChoice > 4) //Loops through different fruits to get a variety to spawn on the level
                    {
                        fruitChoice = 1;
                    }
                }
            }
        }
    }
    
    void GenerationTop()
    {
        for (int x = 0; x < width; x++) //Loops through width of screen
        {
            heightTop = Random.Range(0, -4);
            for (int y = 0; y > heightTop; y--) //Loops through height of roof
            {
                spawnObjTop(dirt, x, y);
            }
            spawnObjTop(grassTop, x, heightTop);
            spikeChanceTop = Random.Range(0, 2); //Random decision if spike will spawn on layer
            if (spikeChanceTop == 1)
            {
                spawnObjTop(spikeTop, x, heightTop - 1);
            }
        }
    }

    void spawnObj(GameObject obj, int width, int height) //Handles spawning tiles for floor
    {
        obj = Instantiate(obj, new Vector3(width-9, height-5, -1f), Quaternion.identity);
        obj.transform.parent = this.transform;
    }
    
    void spawnObjTop(GameObject obj, int width, int height) //Handles spawning tiles for roof
    {
        obj = Instantiate(obj, new Vector3(width-9, height+5, -1f), Quaternion.identity);
        obj.transform.parent = this.transform;
    }
}
