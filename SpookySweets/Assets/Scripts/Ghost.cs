using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] GameObject prefabBullet;
    [SerializeField] Sprite[] sweets;
    float speed;
    Rigidbody2D rb;

    void Start()
    {
        speed = 20f;
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(-7.5f, 0f, 0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        print(GameManager.instance.GetIsTimeUp());
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.position = new Vector2(Mathf.Clamp(rb.position.x, -8, -7), Mathf.Clamp(rb.position.y, -2, 4));
        rb.velocity = movement * speed;

    }


    void Shoot()
    {
        if(GameManager.instance.GetIsTimeUp() != true)
        {
            if (prefabBullet != null)
            {
                GameObject bullet = Instantiate(prefabBullet, transform.position, transform.rotation);
                int losowaGrafika = Random.Range(0, sweets.Length);
                bullet.GetComponent<SpriteRenderer>().sprite = sweets[losowaGrafika];
            }
        }
    }
}
