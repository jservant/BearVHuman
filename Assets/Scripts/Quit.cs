using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Quits game in builds not in unity
        if (Input.GetButtonUp("Cancel"))
    { Debug.Log("pressed escape");
            Application.Quit(); }
    }

    public void DoQuit()
    {
        Debug.Log("has quit game");
        Application.Quit();
    }
}
