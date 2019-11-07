using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    [SerializeField] SpriteRenderer bucketFront;
    
    void Start()
    {
        
        bucketFront.color = new Color(0.3f, 0.3f, 0.4f, 1);
    }
    public void ChangeColor()
    {
        StartCoroutine(ChangeSpriteColor());
    }

    IEnumerator ChangeSpriteColor()
    {
        bucketFront.color = new Color(0.4f, 1, 1, 1);
        yield return new WaitForSeconds(0.2f);
        bucketFront.color = new Color(0.3f, 0.3f, 0.4f, 1);
    }

}
