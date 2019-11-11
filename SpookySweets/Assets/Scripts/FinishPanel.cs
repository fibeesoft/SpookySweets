using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishPanel : MonoBehaviour
{
    [SerializeField] Text txt_pointsCounter;
    [SerializeField] Text txt_highScore;
    [SerializeField] GameObject btn_nextLevel;
    [SerializeField] GameObject txt_lastMessage;

    int level;
    void Start()
    {
        level = 1;
    }

    public void ShowHowManyPoints()
    {
        txt_pointsCounter.text = Points.instance.GetPointsCounter().ToString();
    }

    public void DisplayPanel()
    {
        txt_lastMessage.SetActive(false);
        level = Savings.instance.GetLevel();
        txt_pointsCounter.text = "You got " + Points.instance.GetPointsCounter().ToString() + " sweets";
        GameManager.instance.FinishLevel();
        txt_highScore.text = Savings.instance.GetHighScore().ToString();
        gameObject.SetActive(true);

        if (level == 4)
        {
            btn_nextLevel.SetActive(false);
            txt_lastMessage.SetActive(true);
        }  
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }



}
