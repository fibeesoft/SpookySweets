using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketContainer : MonoBehaviour
{
    float speed = 1.2f;
    float maxRotation = 35f;

    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, maxRotation * Mathf.Sin(Time.time * speed));
    }
}
