using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public static Points instance;
    int pointsCounter;
    [SerializeField] Text txt_pointsCounter;
    [SerializeField] GameObject particle;
    Transform bucket;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        bucket = GameObject.FindGameObjectWithTag("bucketEmpty").GetComponent<Transform>();
        pointsCounter = 0;
    }


    public void AddPoint()
    {
        pointsCounter++;
        txt_pointsCounter.text = pointsCounter.ToString();
        GameObject effect = Instantiate(particle, bucket.transform.position, transform.rotation);
        Destroy(effect, 1f);
    }

    public int GetPointsCounter()
    {
        return pointsCounter;
    }
}
