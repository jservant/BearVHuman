using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosingTries : MonoBehaviour
{
    public string pHumanTag;
    public string HumanTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(HumanTag) || other.CompareTag(pHumanTag))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
           /* if (tagToDestroy == "Player2")
            {
                other.GetComponent<PlayerController>().LoseATryP();
            } */
        }
    }
}
