using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMonster : MonoBehaviour
{

    float speed = 1.5f;
    float maxRotation = 32f;
    void Start()
    {

    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, maxRotation * Mathf.Sin(Time.time * speed));

    }
}
