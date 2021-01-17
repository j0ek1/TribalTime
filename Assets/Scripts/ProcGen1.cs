using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcGen1 : MonoBehaviour
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

    public GameObject banana;
    public GameObject pineapple;
    public GameObject strawberry;
    public GameObject cherries;
    private int randomFruit;
    private int fruitLocation;
    public int fruitCounter = 3;

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
        ObstacleGen(); //Handles obstacle generation for the floor with fruits
        RoofGen(); //Handles generation for the roof
    }

    void ObstacleGen()
    {
        randomFruit = Random.Range(1, 5);
        for (float x = 1; x < 4; x++) //Loops through 3 times
        {
            randomObs = nextObs;
            nextObs = Random.Range(1, 7); //Next obstacle is predetermined
            fruitLocation = Random.Range(0, 2); //Sets random fruit location possibilities
            switch (randomObs) //Current obstacle spawned
            {
                case 1:
                    if ((prevObs == 2 || prevObs == 6) && (nextObs == 2 || nextObs == 6)) //If statements handle which variant of the obstacle will be spawned depending on the obstacles next and previous
                    {
                        spawnObj(Obstacle1, x);
                    }
                    if ((prevObs == 2 || prevObs == 6) && (nextObs != 2 && nextObs != 6))
                    {
                        spawnObj(Obstacle1a, x);
                    }
                    if ((prevObs != 2 && prevObs != 6) && (nextObs == 2 || nextObs == 6))
                    {
                        spawnObj(Obstacle1b, x);
                    }
                    if ((prevObs != 2 && prevObs != 6) && (nextObs != 2 && nextObs != 6))
                    {
                        spawnObj(Obstacle1c, x);
                    }
                    if (fruitLocation == 0) //Spawns random fruit at random given locations
                    {
                        spawnFruit(randomFruit, (6f*x-15f)+1.5f, -1.5f);
                        randomFruit++;
                    }
                    else if (fruitLocation == 1)
                    {
                        spawnFruit(randomFruit, (6f*x-15f)+4.5f, -3.5f);
                        randomFruit++;
                    }
                    break;
                case 2:
                    spawnObj(Obstacle2, x); //No if statements needed as spikes are on either end
                    spawnFruit(randomFruit, (6f*x-15f)+2.5f, -2.5f); //Only one possible fruit spawn location
                    randomFruit++;
                    break;
                case 3:
                    if ((prevObs == 2 || prevObs == 6) && (nextObs == 2 || nextObs == 6))
                    {
                        spawnObj(Obstacle3, x);
                    }
                    if ((prevObs == 2 || prevObs == 6) && (nextObs != 2 && nextObs != 6))
                    {
                        spawnObj(Obstacle3a, x);
                    }
                    if ((prevObs != 2 && prevObs != 6) && (nextObs == 2 || nextObs == 6))
                    {
                        spawnObj(Obstacle3b, x);
                    }
                    if ((prevObs != 2 && prevObs != 6) && (nextObs != 2 && nextObs != 6))
                    {
                        spawnObj(Obstacle3c, x);
                    }
                    if (fruitLocation == 0) //Spawns random fruit at random given locations
                    {
                        spawnFruit(randomFruit, (6f*x-15f)+1.5f, -3.5f);
                        randomFruit++;
                    }
                    else if (fruitLocation == 1)
                    {
                        spawnFruit(randomFruit, (6f*x-15f)+4.5f, -3.5f);
                        randomFruit++;
                    }
                    break;
                case 4:
                    if ((prevObs == 2 || prevObs == 6) && (nextObs == 2 || nextObs == 6))
                    {
                        spawnObj(Obstacle4, x);
                    }
                    if ((prevObs == 2 || prevObs == 6) && (nextObs != 2 && nextObs != 6))
                    {
                        spawnObj(Obstacle4a, x);
                    }
                    if ((prevObs != 2 && prevObs != 6) && (nextObs == 2 || nextObs == 6))
                    {
                        spawnObj(Obstacle4b, x);
                    }
                    if ((prevObs != 2 && prevObs != 6) && (nextObs != 2 && nextObs != 6))
                    {
                        spawnObj(Obstacle4c, x);
                    }
                    if (fruitLocation == 0) //Spawns random fruit at random given locations
                    {
                        spawnFruit(randomFruit, (6f*x-15f)+1.5f, -1.5f);
                        randomFruit++;
                    }
                    else if (fruitLocation == 1)
                    {
                        spawnFruit(randomFruit, (6f*x-15f)+5.5f, -3.5f);
                        randomFruit++;
                    }
                    break;
                case 5:
                    if ((prevObs == 2 || prevObs == 6) && (nextObs == 2 || nextObs == 6))
                    {
                        spawnObj(Obstacle5, x);
                    }
                    if ((prevObs == 2 || prevObs == 6) && (nextObs != 2 && nextObs != 6))
                    {
                        spawnObj(Obstacle5a, x);
                    }
                    if ((prevObs != 2 && prevObs != 6) && (nextObs == 2 || nextObs == 6))
                    {
                        spawnObj(Obstacle5b, x);
                    }
                    if ((prevObs != 2 && prevObs != 6) && (nextObs != 2 && nextObs != 6))
                    {
                        spawnObj(Obstacle5c, x);
                    }
                    if (fruitLocation == 0) //Spawns random fruit at random given locations
                    {
                        spawnFruit(randomFruit, (6f*x-15f)+1.5f, -1.5f);
                        randomFruit++;
                    }
                    else if (fruitLocation == 1)
                    {
                        spawnFruit(randomFruit, (6f*x-15f)+5.5f, -3.5f);
                        randomFruit++;
                    }
                    break;
                case 6:
                    spawnObj(Obstacle6, x); //No if statements needed as spikes are on either end
                    if (fruitLocation == 0) //Spawns random fruit at random given locations
                    {
                        spawnFruit(randomFruit, (6f*x-15f)+2.5f, -2.5f);
                        randomFruit++;
                    }
                    else if (fruitLocation == 1)
                    {
                        spawnFruit(randomFruit, (6f*x-15f)+4.5f, -1.5f);
                        randomFruit++;
                    }
                    break;
            }
            prevObs = randomObs; //Previous obstacle value set
        }
    }

    void RoofGen()
    {
        for (float x = 1; x < 4; x++)
        {
            randomRoof = Random.Range(1, 6); //Random roof selected
            switch (randomRoof) //Random roof spawned into level
            {
                case 1:
                    spawnObj(Roof1, x);
                    break;
                case 2:
                    spawnObj(Roof2, x);
                    break;
                case 3:
                    spawnObj(Roof3, x);
                    break;
                case 4:
                    spawnObj(Roof4, x);
                    break;
                case 5:
                    spawnObj(Roof5, x);
                    break;
                case 6:
                    spawnObj(Roof6, x);
                    break;
            }
        }
    }

    void spawnObj(GameObject obj, float n) //Handles obstacle spawning
    {
        obj = Instantiate(obj, new Vector2((6f*n)-15f, 0), Quaternion.identity); //Spawns object at 6n-15, the sequence for x in the scene where our obstacles need to spawn (-9, -3, 3)
        obj.transform.parent = this.transform;
    }

    void spawnFruit(int fruitSelection, float x, float y)
    {
        switch (fruitSelection)
        {
            case 1:
                banana = Instantiate(banana, new Vector2(x, y), Quaternion.identity);
                banana.transform.parent = this.transform;
                break;
            case 2:
                pineapple = Instantiate(pineapple, new Vector2(x, y), Quaternion.identity);
                pineapple.transform.parent = this.transform;
                break;
            case 3:
                strawberry = Instantiate(strawberry, new Vector2(x, y), Quaternion.identity);
                strawberry.transform.parent = this.transform;
                break;
            case 4:
                cherries = Instantiate(cherries, new Vector2(x, y), Quaternion.identity);
                cherries.transform.parent = this.transform;
                break;
        }
        if (randomFruit == 4)
        {
            randomFruit = 0;
        }
    }
}
