using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [Header("Travelling")]
    [SerializeField] float moveSpeed;    // Determines how fast the AI gets to their desired endpoint
    [SerializeField] float walkDistance; // Determines distance the AI travels
    
    [Header("Time Walking")]
    [SerializeField] int pauseTime;
    [SerializeField] float smallPause = 0.03f;

    [Header("Debug (DO NOT EDIT)")]
    [SerializeField] bool hasNumber = false; // Checks to see if a direction has been assigned to the AI
    [SerializeField] int direction; //For one of 8 directions    

    Vector3 pos;
    
    void Start()
    {
        pos = transform.position;
        StartCoroutine(MoveAI());
    }

    IEnumerator MoveAI()
    {
        float WALKIN = walkDistance; //Creates a new float so it doesn't actually modify the walkDistance var
        while (WALKIN > 0)
        {
            if (hasNumber == false) // If the a AI doesn't have a direction...
            {
                direction = Random.Range(1, 8); // Randomly pick a direction
                /* Directions follow numpad notation, but 6 is 5 and every number after is bumped up, like so:
                 * 6 7 8
                 * 4 * 5
                 * 1 2 3  */
                Debug.Log(direction);
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
                hasNumber = true;
                yield return new WaitForSeconds(smallPause);
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
                pos -= transform.right * Time.deltaTime * moveSpeed;
                hasNumber = true;
                yield return new WaitForSeconds(smallPause);
            }
            
            transform.position = pos;
            WALKIN -= Time.deltaTime; // Time goes down while moving
        }

        if (WALKIN <= 0)
        {
            yield return new WaitForSeconds(pauseTime);
            hasNumber = false;
            StartCoroutine(MoveAI());
        }
    }
}
