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
    [SerializeField] Text txt_timeLeft;
    [SerializeField] Text txt_highScore;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject fspanel;
    int level;
    int highScore;
    string highScorePlayerPrefName;
    bool isHighScoreChanged;
    bool isGameStopped;
    [SerializeField] AudioSource audios;

    void Awake()
    {
        Time.timeScale = 1;
        if (instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }


        if (PlayerPrefs.HasKey("levelPlayerPrefs"))
        {
            level = PlayerPrefs.GetInt("levelPlayerPrefs");
        }
        else
        {
            level = 1;
            PlayerPrefs.SetInt("levelPlayerPrefs", level);
        }

        highScorePlayerPrefName = "hcppn" + level;


        if (PlayerPrefs.HasKey(highScorePlayerPrefName))
        {
            highScore = GetHighScore();
        }
        else
        {
            highScore = 0;
            SetHighScore();
        }
    }


    void Start()
    {
        sweetsQuantity = 30;
        timeToFinish = 30f;
        isTimeUp = false;
        isGameStopped = false;

        panel.SetActive(false);
        isHighScoreChanged = false;
        txt_highScore.text = "High Score: " + GetHighScore();
        audios.Play();
    }
    public int GetHighScore()
    {
        print("highscore for level " + level + "is " + PlayerPrefs.GetInt(highScorePlayerPrefName));
        return PlayerPrefs.GetInt(highScorePlayerPrefName);
        
    }

    public void SetHighScore()
    {
        PlayerPrefs.SetInt(highScorePlayerPrefName, highScore);
        print("highscore for level " + level + "is saved as" + PlayerPrefs.GetInt(highScorePlayerPrefName));
    }

    public int GetLevel()
    {
        print("Level taken form GameManager is: " + PlayerPrefs.GetInt("levelPlayerPrefs"));
        return PlayerPrefs.GetInt("levelPlayerPrefs");
    }

    public void SetLevel(int lev)
    {
        PlayerPrefs.SetInt("levelPlayerPrefs", lev);
        print("level saved as" + PlayerPrefs.GetInt("levelPlayerPrefs"));
    }
    public void FinishLevel()
    {
        int oldHighScore = GetHighScore();
        int score = Points.instance.GetPointsCounter();
        if(score > oldHighScore)
        {
            isHighScoreChanged = true;
            highScore = score;
            SetHighScore();

        }
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
            isGameStopped = true;
            if(isGameStopped)
            {
                FinishLevel();
                panel.GetComponent<FinishPanel>().DisplayPanel();
                if (isHighScoreChanged)
                {
                    panel.GetComponent<FinishPanel>().DisplayBestScorePanel();
                    isHighScoreChanged = false;
                }
                isGameStopped = false;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetHighScores();
            print("high scores reseted");
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

    public void ResetLevel()
    {
        PlayerPrefs.SetInt("levelPlayerPrefs", 1);
    }

    public void ResetHighScores()
    {
        for(int i = 0; i < 4; i++)
        {
            string ppname = "hcppn" + i;
            if (PlayerPrefs.HasKey(ppname))
            {
                PlayerPrefs.SetInt(ppname, 1);
            }
        }
    }
    void OnApplicationQuit()
    {
        ResetLevel();
    }

    public void OpenfsPanel()
    {
        fspanel.SetActive(true);
    }

    public void ClosefsPanel()
    {
        fspanel.SetActive(false);
    }


}
