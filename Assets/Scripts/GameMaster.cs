using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    //STILL NEED TO DO: menu maybe, bounds, score....??? idk more stuff

    [Header("Spawning")]
    public Transform spawner;
    public int bearCount;
    public int humanCount;
    [Header("Win Conditions")]
    [SerializeField] float timer = 180f;
    public Text timerText;
    public bool bearWin = false;
    public bool humanWin = false;
    [Header("Game Objects")]
    public GameObject bear;
    public GameObject human;
    public GameObject pHuman;
    public GameObject pBear;
    public GameObject bearWinScreen;
    public GameObject humanWinScreen;
    [Space]
    bool spawnOnce = false;

    void Start()
    {
        //hides cursor
        Cursor.visible = false;

        for (int i = 0; i < humanCount; i++)
        {
            float spawnX = Random.Range(-7, 2);
            float spawnY = Random.Range(-3, 3);
            spawner.position = new Vector2(spawnX, spawnY);
            Instantiate(human, spawner.position, spawner.rotation);
        }
        for (int i = 0; i < bearCount; i++)
        {
            float spawnX = Random.Range(-2, 7);
            float spawnY = Random.Range(-3, 3);
            spawner.position = new Vector2(spawnX, spawnY);
            Instantiate(bear, spawner.position, spawner.rotation);
        }
        float spawnXH = Random.Range(-7, 2);
        float spawnYH = Random.Range(-3, 3);
        spawner.position = new Vector2(spawnXH, spawnYH);
        Instantiate(pHuman, spawner.position, spawner.rotation);
        float spawnXB = Random.Range(-2, 7);
        float spawnYB = Random.Range(-3, 3);
        spawner.position = new Vector2(spawnXB, spawnYB);
        Instantiate(pBear, spawner.position, spawner.rotation);
    }

    void Update()
    {
        if (bearWin == false)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("F0");
        }

        if (bearWin == true && spawnOnce == false)
        {
            Instantiate(bearWinScreen);
            timerText.text = "";
            timer = 0;
            spawnOnce = true;
        }

        //Quits game in builds not in unity
        if (Input.GetButtonUp("Cancel"))
        {
            Application.Quit();
        }

    }
}
