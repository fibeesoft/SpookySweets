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
    [SerializeField] GameObject bestScorePanel;

    public void ShowHowManyPoints()
    {
        txt_pointsCounter.text = Points.instance.GetPointsCounter().ToString();
    }

    public void DisplayPanel()
    {
        txt_lastMessage.SetActive(false);
        int level = GameManager.instance.GetLevel();
        txt_pointsCounter.text = "You got " + Points.instance.GetPointsCounter().ToString() + " sweets";
        txt_highScore.text = GameManager.instance.GetHighScore().ToString();
        gameObject.SetActive(true);
        print($"level: {level} in DisplayPanel method");

        if (level == 4)
        {
            btn_nextLevel.SetActive(false);
            txt_lastMessage.SetActive(true);
        }  
    }

    public void DisplayBestScorePanel()
    { 
        bestScorePanel.SetActive(true);
    }

    public void CloseBestScorePanel()
    {
        bestScorePanel.SetActive(false);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }



}
