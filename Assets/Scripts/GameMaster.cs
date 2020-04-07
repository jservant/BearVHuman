using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    //STILL NEED TO DO: menu maybe, bounds, score....??? idk more stuff

    [SerializeField] float timer = 180f;
    public Text timerText;

    void Start()
    {
        //hides cursor
        Cursor.visible = false;

    }

    void Update()
    {
        //Quits game in builds not in unity
        if (Input.GetButtonUp("Cancel"))
        {
            Application.Quit();
        }

        timer -= Time.deltaTime;
        timerText.text = timer.ToString("F0");
    }
}
