using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBackground : MonoBehaviour //Simple script to delete objects that are too far from the camera to be seen
{
    public GameObject deleteBg;

    void Start()
    {
        deleteBg = GameObject.Find("DeleteBackground");
    }

    void Update()
    {
        if (transform.position.x < deleteBg.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
