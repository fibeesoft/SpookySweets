using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ghost : MonoBehaviour
{
    [SerializeField] GameObject prefabBullet;
    [SerializeField] Sprite[] sweets;
    BtnUp btnUp;
    BtnDown btnDown;
    float speed;
    Rigidbody2D rb;
    float direction;

    void Start()
    {
        speed = 20f;
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(-6f, 0f, 0f);
        direction = 0;
        btnUp = FindObjectOfType<BtnUp>().GetComponent<BtnUp>();
        btnDown = FindObjectOfType<BtnDown>().GetComponent<BtnDown>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if (btnUp.GetIsPressed())
        {
            direction = 0.5f;
        }else if (btnDown.GetIsPressed())
        {
            direction = -0.5f;
        }
        else
        {
            direction = 0;
        }

        if(Input.GetAxis("Vertical") != 0)
        {
            direction = Input.GetAxis("Vertical");
        }

        Vector2 movement = new Vector2(0, direction);
        rb.position = new Vector2(rb.position.x, Mathf.Clamp(rb.position.y, -2, 4));
        rb.velocity = movement * speed;
    }


    public void Shoot()
    {
        if(GameManager.instance.GetIsTimeUp() != true)
        {
            if (prefabBullet != null)
            {
                if(CandyRow.instance.GetCandiesLeft() > 0)
                {
                    GameObject bullet = Instantiate(prefabBullet, transform.position, transform.rotation);
                    int losowaGrafika = Random.Range(0, sweets.Length);
                    bullet.GetComponent<SpriteRenderer>().sprite = sweets[losowaGrafika];
                    CandyRow.instance.ShootTheCandy();
                }
            }
        }
    }
}
