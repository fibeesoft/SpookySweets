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
        highScorePlayerPrefName = "hcppn";
        highScoreArray = new int[4];

        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }

        if(PlayerPrefs.HasKey("levelPlayerPrefs"))
        {
            level = PlayerPrefs.GetInt("levelPlayerPrefs");
        }
        else
        {
            level = 1;
            PlayerPrefs.SetInt("levelPlayerPrefs", level);
        }


        if (PlayerPrefs.HasKey(highScorePlayerPrefName + level))
        {
            highScoreArray[level - 1] = PlayerPrefs.GetInt(highScorePlayerPrefName + level);
        }
        else
        {
            highScoreArray[level - 1] = 0;
            PlayerPrefs.SetInt(highScorePlayerPrefName + level, highScoreArray[level - 1]);
        }
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(highScorePlayerPrefName + level);
    }

    public void SetHighScore(int highScore)
    {
        PlayerPrefs.SetInt(highScorePlayerPrefName + level, highScore);
    }
    public int GetLevel()
    {
        return PlayerPrefs.GetInt("levelPlayerPrefs");
    }

    public void SetLevel(int lev)
    {
        level = lev;
        PlayerPrefs.SetInt("levelPlayerPrefs", level);
    }

    public void ResetLevel()
    {
        PlayerPrefs.SetInt("levelPlayerPrefs", 1);
    }

    void OnApplicationQuit()
    {
        ResetLevel();
    }
}
