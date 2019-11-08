using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinMonster : MonoBehaviour
{
    float speed = 1.5f;
    float maxRotation = 35f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, maxRotation * Mathf.Sin(Time.time * speed));
    }
}
