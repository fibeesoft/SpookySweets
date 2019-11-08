using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savings : MonoBehaviour
{
    public static Savings instance;
    int level;
    void Awake()
    {
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
