using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int sweetsQuantity;
    float timeToFinish;
    bool isTimeUp;
    bool isGameOver;
    [SerializeField] Text txt_timeLeft;
    [SerializeField] GameObject panel;


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

    public void FinishLevel()
    {
       int level = Savings.instance.GetLevel();
        int oldHighScore = Savings.instance.GetHighScore();
        int score = Points.instance.GetPointsCounter();
        if(score > oldHighScore)
        {
            Savings.instance.SetHighScore(score);
        }
    }

    void Start()
    {
        sweetsQuantity = 30;
        timeToFinish = 30f;
        isTimeUp = false;
        panel.SetActive(false);

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
            panel.GetComponent<FinishPanel>().DisplayPanel();
        }
    }

    public bool GetIsTimeUp()
    {
        return isTimeUp;
        
    }

    public void PlayAgain()
    {
        LevelManager.instance.LevelUp();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }




}
