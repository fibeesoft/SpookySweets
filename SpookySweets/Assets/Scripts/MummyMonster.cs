using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyMonster : MonoBehaviour
{
    float speed = 1.5f;
    float maxRotation = 4f;
    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(0f,  maxRotation * Mathf.Sin(Time.time * speed), 0f);
    }
}
