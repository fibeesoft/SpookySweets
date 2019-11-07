using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{
    bool isMainMusicOn;
    [SerializeField] Image btnSound;
    void Start()
    {
        
        isMainMusicOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MainMusicSwitch()
    {
        isMainMusicOn = !isMainMusicOn;
        if (isMainMusicOn)
        {
            btnSound.color = new Color32(255,255,255,255);
        }
        else
        {
            btnSound.color = new Color32(132, 32, 32, 255);
        }
    }
}
