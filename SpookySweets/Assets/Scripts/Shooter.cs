using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    Rigidbody2D rb;
    float speed;
    Bucket bucketScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bucketScript = FindObjectOfType<Bucket>().GetComponent<Bucket>();
        speed = 20f;
        Shoot();
    }

    void Shoot()
    {
        rb.AddForce(new Vector2(2.4f * speed, 1.6f * speed), ForceMode2D.Impulse);
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "bucket")
        {
            Destroy(gameObject, 0.0f);
            Points.instance.AddPoint();
            bucketScript.ChangeColor();
        }
    }
}
