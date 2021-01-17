using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgTitleScreen : MonoBehaviour
{
    public GameObject Obstacle1; //Possible obstacles that can be generated
    public GameObject Obstacle1a;
    public GameObject Obstacle1b;
    public GameObject Obstacle1c;
    public GameObject Obstacle2;
    public GameObject Obstacle3;
    public GameObject Obstacle3a;
    public GameObject Obstacle3b;
    public GameObject Obstacle3c;
    public GameObject Obstacle4;
    public GameObject Obstacle4a;
    public GameObject Obstacle4b;
    public GameObject Obstacle4c;
    public GameObject Obstacle5;
    public GameObject Obstacle5a;
    public GameObject Obstacle5b;
    public GameObject Obstacle5c;
    public GameObject Obstacle6;
    private int randomObs; //Holds the value of the random obstacle to be spawned
    private int nextObs; //Holds the value of the next obstacle to be spawned
    private int prevObs = 2; //Holds the value of the previous obstacle spawned

    public GameObject Roof1;
    public GameObject Roof2;
    public GameObject Roof3;
    public GameObject Roof4;
    public GameObject Roof5;
    public GameObject Roof6;
    private int randomRoof;

    public GameObject background;
    private bool spawnBg = true;
    private int bgLoops = 0;

    public GameObject mainCamera;
    private Vector2 cameraPos = new Vector2(0f, 0f);
    private int loops = 1;

    private int xPos = 1;

    void Start()
    {
        int nextObsCase = Random.Range(1, 5); //Generating the first object before the rest (player cannot spawn on spikes)
        switch (nextObsCase)
        {
            case 1:
                nextObs = 1;
                break;
            case 2:
                nextObs = 3;
                break;
            case 3:
                nextObs = 4;
                break;
            case 4:
                nextObs = 5;
                break;
        }
        FloorGen(); //Handles obstacle generation for the floor with fruits
        RoofGen(); //Handles generation for the roof
    }

    void FixedUpdate()
    {
        mainCamera.transform.position = cameraPos; //Camera is scrolling through screen
        cameraPos.x += .02f;
        if (cameraPos.x > 18f*loops) //Everytime it passes one set of generation, the next is called
        {
            loops = loops + 2;
            bgLoops = bgLoops + 36;
            xPos = xPos + 6;
            spawnBg = true;
            FloorGen();
            RoofGen();
        }
    }

    void FloorGen()
    {
        for (float x = xPos; x < xPos + 6; x++)
        {
            randomObs = nextObs;
            nextObs = Random.Range(1, 7); //Next obstacle is predetermined
            if (spawnBg)
            {
                spawnObj2(background, bgLoops, 15f);
                spawnObj2(background, bgLoops+18, 15f);
                spawnBg = false;
            }          
            switch (randomObs) //Current obstacle spawned
            {
                case 1:
                    if ((prevObs == 2 || prevObs == 6) && (nextObs == 2 || nextObs == 6)) //If statements handle which variant of the obstacle will be spawned depending on the obstacles next and previous
                    {
                        spawnObj1(Obstacle1, x, 1f);
                    }
                    if ((prevObs == 2 || prevObs == 6) && (nextObs != 2 && nextObs != 6))
                    {
                        spawnObj1(Obstacle1a, x, 1f);
                    }
                    if ((prevObs != 2 && prevObs != 6) && (nextObs == 2 || nextObs == 6))
                    {
                        spawnObj1(Obstacle1b, x, 1f);
                    }
                    if ((prevObs != 2 && prevObs != 6) && (nextObs != 2 && nextObs != 6))
                    {
                        spawnObj1(Obstacle1c, x, 1f);
                    }
                    break;
                case 2:
                    spawnObj1(Obstacle2, x, 1f); //No if statements needed as spikes are on either end
                    break;
                case 3:
                    if ((prevObs == 2 || prevObs == 6) && (nextObs == 2 || nextObs == 6))
                    {
                        spawnObj1(Obstacle3, x, 1f);
                    }
                    if ((prevObs == 2 || prevObs == 6) && (nextObs != 2 && nextObs != 6))
                    {
                        spawnObj1(Obstacle3a, x, 1f);
                    }
                    if ((prevObs != 2 && prevObs != 6) && (nextObs == 2 || nextObs == 6))
                    {
                        spawnObj1(Obstacle3b, x, 1f);
                    }
                    if ((prevObs != 2 && prevObs != 6) && (nextObs != 2 && nextObs != 6))
                    {
                        spawnObj1(Obstacle3c, x, 1f);
                    }
                    break;
                case 4:
                    if ((prevObs == 2 || prevObs == 6) && (nextObs == 2 || nextObs == 6))
                    {
                        spawnObj1(Obstacle4, x, 1f);
                    }
                    if ((prevObs == 2 || prevObs == 6) && (nextObs != 2 && nextObs != 6))
                    {
                        spawnObj1(Obstacle4a, x, 1f);
                    }
                    if ((prevObs != 2 && prevObs != 6) && (nextObs == 2 || nextObs == 6))
                    {
                        spawnObj1(Obstacle4b, x, 1f);
                    }
                    if ((prevObs != 2 && prevObs != 6) && (nextObs != 2 && nextObs != 6))
                    {
                        spawnObj1(Obstacle4c, x, 1f);
                    }
                    break;
                case 5:
                    if ((prevObs == 2 || prevObs == 6) && (nextObs == 2 || nextObs == 6))
                    {
                        spawnObj1(Obstacle5, x, 1f);
                    }
                    if ((prevObs == 2 || prevObs == 6) && (nextObs != 2 && nextObs != 6))
                    {
                        spawnObj1(Obstacle5a, x, 1f);
                    }
                    if ((prevObs != 2 && prevObs != 6) && (nextObs == 2 || nextObs == 6))
                    {
                        spawnObj1(Obstacle5b, x, 1f);
                    }
                    if ((prevObs != 2 && prevObs != 6) && (nextObs != 2 && nextObs != 6))
                    {
                        spawnObj1(Obstacle5c, x, 1f);
                    }
                    break;
                case 6:
                    spawnObj1(Obstacle6, x, 1f); //No if statements needed as spikes are on either end
                    break;
            }
            prevObs = randomObs; //Previous obstacle value set
        }
    }

    void RoofGen()
    {
        for (float x = xPos; x < xPos + 6; x++)
        {
            randomRoof = Random.Range(1, 6); //Random roof selected
            switch (randomRoof) //Random roof spawned into level
            {
                case 1:
                    spawnObj1(Roof1, x, 1f);
                    break;
                case 2:
                    spawnObj1(Roof2, x, 1f);
                    break;
                case 3:
                    spawnObj1(Roof3, x, 1f);
                    break;
                case 4:
                    spawnObj1(Roof4, x, 1f);
                    break;
                case 5:
                    spawnObj1(Roof5, x, 1f);
                    break;
                case 6:
                    spawnObj1(Roof6, x, 1f);
                    break;
            }
        }
    }

    void spawnObj1(GameObject obj, float n, float z) //Handles obstacle spawning for the floor
    {
        obj = Instantiate(obj, new Vector3((6f * n) - 15f, 0f, z), Quaternion.identity); //Spawns object at 6n-15, the sequence for x in the scene where our obstacles need to spawn (-9, -3, 3)
        obj.transform.parent = this.transform;
    }

    void spawnObj2(GameObject obj, float n, float z) //Handles obstacle spawning for the floor
    {
        obj = Instantiate(obj, new Vector3(n, 0f, z), Quaternion.identity); //Spawns object at 6n-15, the sequence for x in the scene where our obstacles need to spawn (-9, -3, 3)
        obj.transform.parent = this.transform;
    }
}
