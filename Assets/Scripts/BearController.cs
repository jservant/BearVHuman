using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BearController : MonoBehaviour
{
    public float speed;//for movement
    public int tries;//tries for eating ppl
    public Text triesText;//displaying tries on screen

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        float moveH = Input.GetAxisRaw("Horizontal");
        float moveV = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(moveH, moveV);
        rb.velocity = move * speed;
    }

    public void LoseATry()
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
