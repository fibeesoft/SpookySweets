using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] SpriteRenderer bgSprite;
    [SerializeField] Sprite[] bgSpriteArray;
    [SerializeField] GameObject[] levelChangeObjectsArray;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    int level;
    void Start()
    {
        level = GameManager.instance.GetLevel();
        bgSprite.sprite = bgSpriteArray[level-1];
        LevelChooser();
    }

    public void LevelUp()
    {
        if(level < 4)
        {
            level++;
            GameManager.instance.SetLevel(level);
            print("level up :" + level);
        }
        else
        {
            print("Max level achieved");
        }

    }

    void LevelChooser()
    {
        foreach(var i in levelChangeObjectsArray)
        {
            i.SetActive(false);
        }

        if(level == 1)
        {
            
        }
        else if(level == 2)
        {
            levelChangeObjectsArray[0].SetActive(true);
        }
        else if(level == 3)
        {
            levelChangeObjectsArray[1].SetActive(true);
        }
        else if(level == 4)
        {
            levelChangeObjectsArray[2].SetActive(true);
        }
    }
}
