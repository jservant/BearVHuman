using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearSwing : MonoBehaviour
{
    public string pHumanTag;
    public string HumanTag;
    [SerializeField] float despawnTime;

    void Update()
    {
        despawnTime -= Time.deltaTime;
        if (despawnTime <= 0) { Destroy(gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(HumanTag) || other.CompareTag(pHumanTag))
        {
            if (other.CompareTag(pHumanTag))
            {
                GameObject.FindWithTag("GameController").GetComponent<GameMaster>().bearWin = true;
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
