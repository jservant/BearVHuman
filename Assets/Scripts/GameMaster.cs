using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    //STILL NEED TO DO: menu maybe, bounds, score....??? idk more stuff

    // Start is called before the first frame update
    void Start()
    {
        //hides cursor
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Quits game in builds not in untiy
        if (Input.GetButtonUp("Cancel"))
        {
            Application.Quit();
        }
    }
}
