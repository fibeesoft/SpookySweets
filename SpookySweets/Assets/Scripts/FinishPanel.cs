using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishPanel : MonoBehaviour
{
    [SerializeField] Text txt_pointsCounter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowHowManyPoints()
    {
        txt_pointsCounter.text = Points.instance.GetPointsCounter().ToString();
    }

    public void DisplayPanel()
    {
        txt_pointsCounter.text = "You got " + Points.instance.GetPointsCounter().ToString() + " sweets";
        gameObject.SetActive(true);
        
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }



}
