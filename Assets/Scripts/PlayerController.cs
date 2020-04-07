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
            float moveH = Input.GetAxisRaw("Horizontal");
            float moveV = Input.GetAxisRaw("Vertical");
            Vector2 move = new Vector2(moveH, moveV);
            rb.velocity = move * speed;
            if (Input.GetAxisRaw("Horizontal") > .1f) { sr.flipX = true; }
            if (Input.GetAxisRaw("Horizontal") < -.1f) { sr.flipX = false; }
            if (Input.GetButtonDown("Jump"))
            {
                Swing();
            }
        }

        if (gameObject.CompareTag("PHuman"))
        {
            float moveH = Input.GetAxisRaw("Horizontal2");
            float moveV = Input.GetAxisRaw("Vertical2");
            Vector2 move = new Vector2(moveH, moveV);
            rb.velocity = move * speed;
            if (Input.GetAxisRaw("Horizontal2") > .1f) { sr.flipX = true; }
            if (Input.GetAxisRaw("Horizontal2") < -.1f) { sr.flipX = false; }
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