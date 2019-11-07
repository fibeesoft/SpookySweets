using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnUp : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    bool ispressed = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        ispressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ispressed = false;
    }

    public bool GetIsPressed()
    {
        return ispressed;
    }

}
