using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandyRow : MonoBehaviour
{
    public static CandyRow instance;
    [SerializeField] GameObject candyRowElementPrefab;
    [SerializeField] Transform parent;
    int candiesQuantity;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        candiesQuantity = 80;
        GenerateCandies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateCandies()
    {
        Vector3 pos = new Vector3(-25f, -4, 0f);
        float posX = -940f;
        for (int i = 0; i < candiesQuantity; i++)
        {
            GameObject candyRowElement = Instantiate(candyRowElementPrefab, pos, Quaternion.identity, transform);
            candyRowElement.GetComponent<RectTransform>().anchoredPosition = new Vector3(posX, 0f, 0f);
            posX += (1880f/80);
        }
    }

    void DestroyCandy()
    {
        Destroy(GameObject.FindGameObjectWithTag("candyLeft"), 0f);
    }
    public void ShootTheCandy()
    {
        candiesQuantity--;
        DestroyCandy();
    }

    public int GetCandiesLeft()
    {
        return candiesQuantity;
    }
}
