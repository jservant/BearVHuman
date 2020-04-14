using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //for pausing
    GameObject[] pauseObjects;
    GameObject[] howObjects;

    // Start is called before the first frame update
    void Start()
    {
        //pausing
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePaused();
        //How To
        Time.timeScale = 1;
        howObjects = GameObject.FindGameObjectsWithTag("HowTo");
        hideHow();
    }

    // Update is called once per frame
    void Update()
    {
        //pausing, using p for pause and unpause buttoon
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Debug.Log("high");
                Time.timeScale = 1;
                hidePaused();
            }
        }
        // How to
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showHow();
            }
            else if (Time.timeScale == 0)
            {
                Debug.Log("hello");
                Time.timeScale = 1;
                hideHow();
            }
        }
    }
    
        //Reloads level
    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    //controls the pausing of the scene
    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    public void howControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showHow();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hideHow();
        }
    }

    //shows objescts with ShowOnPause tag
    void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
            Cursor.visible = true;
        }
    }

    void showHow()
    {
        foreach (GameObject g in howObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
            Cursor.visible = false;
        }
    }
    
    void hideHow()
    {
        foreach (GameObject g in howObjects)
        {
            g.SetActive(false);
        }
    }

    //loads inputted level
    void LoadLevel(string level)
    {
        Application.LoadLevel(level);
    }
}
