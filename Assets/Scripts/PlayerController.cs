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
    [Header("Clamps")]
    [SerializeField] float clampMinX;
    [SerializeField] float clampMaxX;
    [SerializeField] float clampMinY;
    [SerializeField] float clampMaxY;


    Rigidbody2D rb;
    SpriteRenderer sr;
    public SpriteRenderer srSwing;

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
            if (Input.GetAxisRaw("Horizontal") > .1f) { sr.flipX = true; srSwing.flipX = true; } // flipX being true means player is moving right
            if (Input.GetAxisRaw("Horizontal") < -.1f) { sr.flipX = false; srSwing.flipX = false; }
            if (Input.GetButtonDown("Jump")) { Swing(); }
            if (sr.flipX == true) { swinger.localPosition = new Vector2(0.5f, 0); }
            if (sr.flipX == false) { swinger.localPosition = new Vector2(-0.5f, 0); }
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

        if (transform.position.x < clampMinX) transform.position = new Vector2(clampMinX, transform.position.y);
        if (transform.position.x > clampMaxX) transform.position = new Vector2(clampMaxX, transform.position.y);
        if (transform.position.y < clampMinY) transform.position = new Vector2(transform.position.x, clampMinY);
        if (transform.position.y > clampMaxY) transform.position = new Vector2(transform.position.x, clampMaxY);

    }

    void Swing()
    {
        Instantiate(hit, swinger.position, swinger.rotation);
    }
}