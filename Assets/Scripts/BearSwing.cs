using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearSwing : MonoBehaviour
{
    public string pHumanTag;
    public string HumanTag;
    public string CopTag;
    public Transform spawner;
    public GameObject cop;
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
            Destroy(other.gameObject);
            Destroy(gameObject);
            if (other.CompareTag(pHumanTag))
            { GameObject.FindWithTag("GameController").GetComponent<GameMaster>().bearWin = true; }
            else
            {
                GameObject.FindWithTag("GameController").GetComponent<GameMaster>().bearTries--;
                float spawnX = Random.Range(-7, 7);
                float spawnY = Random.Range(-3, 3);
                spawner.position = new Vector2(spawnX, spawnY);
                Instantiate(cop, spawner.position, spawner.rotation);
            }
        }
        if (other.CompareTag(CopTag)) { GameObject.FindWithTag("GameController").GetComponent<GameMaster>().humanWin = true; }
    }
}
