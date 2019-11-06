using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int sweetsQuantity;
    float timeToFinish;
    bool isTimeUp;
    bool isGameOver;
    [SerializeField] Text txt_timeLeft;

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

    void Start()
    {
        sweetsQuantity = 30;
        timeToFinish = 30f;
        isTimeUp = false;
    }

    void Update()
    {
        if(timeToFinish > 0)
        {
            timeToFinish -= Time.deltaTime;
            txt_timeLeft.text = timeToFinish.ToString("0");
        }
        else
        {
            isTimeUp = true;
        }
    }

    public bool GetIsTimeUp()
    {
        return isTimeUp;
    }

    

}
