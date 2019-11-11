using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savings : MonoBehaviour
{
    public static Savings instance;
    int level;
    int[] highScoreArray;
    string highScorePlayerPrefName;

    void Awake()
    {

        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

}
