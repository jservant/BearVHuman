using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    int direction; //For one of 8 directions
    public float walkTime;
    int pauseTime = 1;
    float smallPause = 0.03f;
    [SerializeField()] float moveSpeed;

    Vector3 pos;
    
    void Start()
    {
        pos = transform.position;
        StartCoroutine(MoveAI());
    }

    IEnumerator MoveAI()
    {
        float WALKIN = walkTime;
        while (WALKIN > 0)
        {
            direction = Random.Range(1, 8); // Randomly pick a direction
            /* Directions follow numpad notation, but 6 is 5 and every number after is bumped up, like so:
             * 6 7 8
             * 4 * 5
             * 1 2 3  */
            Debug.Log(direction);
            if (direction == 1) //Southwest
            {
                pos -= transform.up * Time.deltaTime * moveSpeed;
                pos -= transform.right * Time.deltaTime * moveSpeed;
                yield return new WaitForSeconds(smallPause);
            }
            if (direction == 2) //South
            {
                pos -= transform.up * Time.deltaTime * moveSpeed;
                yield return new WaitForSeconds(smallPause);
            }
            if (direction == 3) //Southeast
            {
                pos -= transform.up * Time.deltaTime * moveSpeed;
                pos += transform.right * Time.deltaTime * moveSpeed;
                yield return new WaitForSeconds(smallPause);
            }
            if (direction == 4) //West
            {
                pos -= transform.right * Time.deltaTime * moveSpeed;
                yield return new WaitForSeconds(smallPause);
            }
            if (direction == 5) //East
            {
                pos += transform.right * Time.deltaTime * moveSpeed;
                yield return new WaitForSeconds(smallPause);
            }
            if (direction == 6) //Northwest
            {
                pos += transform.up * Time.deltaTime * moveSpeed;
                pos -= transform.right * Time.deltaTime * moveSpeed;
                yield return new WaitForSeconds(smallPause);
            }
            if (direction == 7) //North
            {
                pos += transform.up * Time.deltaTime * moveSpeed;
                yield return new WaitForSeconds(smallPause);
            }
            if (direction == 8) //Northeast
            {
                pos += transform.up * Time.deltaTime * moveSpeed;
                pos -= transform.right * Time.deltaTime * moveSpeed;
                yield return new WaitForSeconds(smallPause);
            }
            transform.position = pos;
            WALKIN -= Time.deltaTime;
        }
        
        yield return new WaitForSeconds(pauseTime);
    }
}
