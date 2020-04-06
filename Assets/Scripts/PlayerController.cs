using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed; //for movement
    public int tries; //tries for eating ppl
    public GameObject hit;
    public Transform swinger;
    public Sprite[] sprites;

    Rigidbody2D rb;
    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprites[Random.Range(0, sprites.Length)];
    }

    void Update()
    {
        if (gameObject.CompareTag("PBear"))
        {
            float moveHB = Input.GetAxisRaw("Horizontal");
            float moveVB = Input.GetAxisRaw("Vertical");
            Vector2 move = new Vector2(moveHB, moveVB);
            rb.velocity = move * speed;
            if (Input.GetButtonDown("Jump"))
            {
                Swing();
            }
        }

        if (gameObject.CompareTag("PHuman"))
        {
            //movement
            float moveHH = Input.GetAxisRaw("Horizontal2");
            float moveVH = Input.GetAxisRaw("Vertical2");
            Vector2 move = new Vector2(moveHH, moveVH);
            rb.velocity = move * speed;
        }

    }

    public void Swing()
    {
        Instantiate(hit, swinger.position, swinger.rotation);
    }

    public void LoseATry()
    {
        tries--;

        if (tries <= 0)
        {
            Destroy(gameObject);
        }
    }
}