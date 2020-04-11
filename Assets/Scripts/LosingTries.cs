using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosingTries : MonoBehaviour
{
    public string tagToDestroy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagToDestroy))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            if (tagToDestroy == "Player2")
            {
                other.GetComponent<PersonController>().LoseATryP();
            }
        }
    }
}
