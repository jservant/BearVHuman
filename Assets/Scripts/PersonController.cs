using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonController : MonoBehaviour
{
    public float speed;//for movement
    public int tries;//PLACE HOLDING TO TEST BEAR SCRIPT
    public Text triesText;//displaying tries on screen
    [SerializeField] Sprite[] sprites;

    Rigidbody2D rb;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprites[Random.Range(0, sprites.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        float moveH = Input.GetAxisRaw("Horizontal2");
        float moveV = Input.GetAxisRaw("Vertical2");
        Vector2 move = new Vector2(moveH, moveV);
        rb.velocity = move * speed;
    }

    public void LoseATryP()
    {
        tries--;
        triesText.text = "";

        if (tries <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            for (int i = 0; i < tries; i++)
            {
                triesText.text += "B";
            }
        }
    }
}
