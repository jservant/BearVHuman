using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{
    public Sprite bearWinScreen;
    public Sprite humanWinScreen;

    SpriteRenderer sr;
    
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        if (GameObject.FindWithTag("GameController").GetComponent<GameMaster>().bearWin == true)
        {
            sr.sprite = bearWinScreen;
        }
    }
}
