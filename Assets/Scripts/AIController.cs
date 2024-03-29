﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [Header("Travelling")]
    [SerializeField] float moveSpeed;    // Determines how fast the AI gets to their desired endpoint
    [SerializeField] float walkDistance; // Determines distance the AI travels (should get randomized)
    [SerializeField] int direction; //For one of 8 directions

    [Header("Time Walking")]
    [SerializeField] float pauseTime; // How long the AI stands still for after reaching the endpoint of where it was going (should get randomized)
    [SerializeField] float smallPause = 0.03f; // How many units the AI moves in each increment
    // Keep smallPause small so it actually looks like walking and not quick teleporting

    [Header("Debug")]
    [SerializeField] int debugDirection = 0; //Overrides random direction selection (for debugging)
    [SerializeField] bool printDirection = false;
    [Space]
    [SerializeField] bool north = false;
    [SerializeField] bool south = false;
    [SerializeField] bool east = false;
    [SerializeField] bool west = false;

    [Header("Clamps")]
    [SerializeField] float clampMinX;
    [SerializeField] float clampMaxX;
    [SerializeField] float clampMinY;
    [SerializeField] float clampMaxY;

    [Header("Sprites")]
    [SerializeField] Sprite[] sprites;
    public GameObject hit;
    public Transform hitSpawner;

    bool hasNumber = false; // DO NOT DELETE, causes AI to move rapidly
    float hitTimer;
    bool canSwing = true;
    public SpriteRenderer swingSR;

    Vector3 pos;
    SpriteRenderer sr;
    
    void Start()
    {
        pos = transform.position;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprites[Random.Range(0, sprites.Length)];
        pauseTime = Random.Range(1, 3);
        hitTimer = Random.Range(10, 100);
        StartCoroutine(StartPause());
    }

    IEnumerator StartPause()
    {
        yield return new WaitForSeconds(pauseTime);
        StartCoroutine(MoveAI());
    }

    IEnumerator MoveAI()
    {
        float WALKIN = walkDistance; //Creates a new float so it doesn't actually modify the walkDistance var
        while (WALKIN > 0)
        {
            if (hasNumber == false)
            {   
                /* Directions follow numpad notation, but 6 is 5 and every number after is bumped up, like so:
                    * 6 7 8
                    * 4 * 5
                    * 1 2 3  */
                if (debugDirection >= 1) { direction = debugDirection; } 
                else { direction = Random.Range(1, 8); } /* Randomly pick a direction */

                if (north == true) { direction = Random.Range(1, 5); north = false; }
                if (south == true) { direction = Random.Range(4, 8); south = false; }
                if (east == true) 
                {
                    if (direction == 3) { direction = 1; }
                    if (direction == 5) { direction = 4; }
                    if (direction == 8) { direction = 6; }
                    east = false;
                }
                if (west == true) 
                {
                    if (direction == 1) { direction = 3; }
                    if (direction == 4) { direction = 5; }
                    if (direction == 6) { direction = 8; }
                    west = false;
                }

                if (direction == 3 || direction == 5 || direction == 8) { sr.flipX = true; }
                if (direction == 1 || direction == 4 || direction == 6) { sr.flipX = false; }

                if (printDirection == true) { Debug.Log(direction); }
                pauseTime = Random.Range(1, 3);
                walkDistance = Random.Range(.5f, 2);
            }

            if (direction == 1) //Southwest
            {
                pos -= transform.up * Time.deltaTime * moveSpeed;
                pos -= transform.right * Time.deltaTime * moveSpeed;
                hasNumber = true;
                yield return new WaitForSeconds(smallPause);
            }
            if (direction == 2) //South
            {
                pos -= transform.up * Time.deltaTime * moveSpeed;
                yield return new WaitForSeconds(smallPause);
                hasNumber = true;
            }
            if (direction == 3) //Southeast
            {
                pos -= transform.up * Time.deltaTime * moveSpeed;
                pos += transform.right * Time.deltaTime * moveSpeed;
                hasNumber = true;
                yield return new WaitForSeconds(smallPause);
            }
            if (direction == 4) //West
            {
                pos -= transform.right * Time.deltaTime * moveSpeed;
                hasNumber = true;
                yield return new WaitForSeconds(smallPause);
            }
            if (direction == 5) //East
            {
                pos += transform.right * Time.deltaTime * moveSpeed;
                hasNumber = true;
                yield return new WaitForSeconds(smallPause);
            }
            if (direction == 6) //Northwest
            {
                pos += transform.up * Time.deltaTime * moveSpeed;
                pos -= transform.right * Time.deltaTime * moveSpeed;
                hasNumber = true;
                yield return new WaitForSeconds(smallPause);
            }
            if (direction == 7) //North
            {
                pos += transform.up * Time.deltaTime * moveSpeed;
                hasNumber = true;
                yield return new WaitForSeconds(smallPause);
            }
            if (direction == 8) //Northeast
            {
                pos += transform.up * Time.deltaTime * moveSpeed;
                pos += transform.right * Time.deltaTime * moveSpeed;
                hasNumber = true;
                yield return new WaitForSeconds(smallPause);
            }
            
            transform.position = pos;
            WALKIN -= Time.deltaTime; // Time goes down while moving

            if (transform.position.x < clampMinX) // West
                { transform.position = new Vector3(clampMinX, transform.position.y); west = true; WALKIN = 0; }
            if (transform.position.x > clampMaxX) // East
                { transform.position = new Vector3(clampMaxX, transform.position.y); east = true; WALKIN = 0; }
            if (transform.position.y < clampMinY) // South
                { transform.position = new Vector3(transform.position.x, clampMinY); south = true; WALKIN = 0; }
            if (transform.position.y > clampMaxY) // North
                { transform.position = new Vector3(transform.position.x, clampMaxY); north = true; WALKIN = 0; }
        }

        if (WALKIN <= 0)
        {
            yield return new WaitForSeconds(pauseTime);
            hasNumber = false;
            StartCoroutine(MoveAI());
        }

        if (gameObject.CompareTag("Bear"))
        {
            BearSwing();
        }
    }

    private void Update()
    {
        if (gameObject.CompareTag("Bear"))
        { 
            if (sr.flipX == true) { hitSpawner.localPosition = new Vector2(0.5f, 0); swingSR.flipX = true; }
            if (sr.flipX == false) { hitSpawner.localPosition = new Vector2(-0.5f, 0); swingSR.flipX = false; }
            hitTimer -= Time.deltaTime;
        }
    }

    void BearSwing()
    {
        if (hitTimer <= 0 && canSwing == true)
        {
            Instantiate(hit, hitSpawner.position, hitSpawner.rotation);
            canSwing = false;
        }
    }
}
