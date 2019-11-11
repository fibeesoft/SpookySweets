using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketContainer : MonoBehaviour
{
    float speed = 1.2f;
    float maxRotation = 35f;
    float xMaxPos = 1;

    int level;
    void Start()
    {
        level = GameManager.instance.GetLevel();
    }


    void Update()
    {
        if(level <= 2)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, maxRotation * Mathf.Sin(Time.time * speed));
           
        }
        else
        {
            transform.position = new Vector3(xMaxPos * Mathf.Sin(Time.time * speed) + 5, 0f, 0f);
        }
        
    }
}
