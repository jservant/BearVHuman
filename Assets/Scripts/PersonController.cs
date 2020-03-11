﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    public float speed;//for movement

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
        float moveH = Input.GetAxisRaw("Horizontal2");
        float moveV = Input.GetAxisRaw("Vertical2");
        Vector2 move = new Vector2(moveH, moveV);
        rb.velocity = move * speed;
    }
}
