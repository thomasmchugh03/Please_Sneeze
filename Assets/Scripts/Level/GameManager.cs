﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TileAutomata board;
    public static GameManager instance = null;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject)
;       }

        DontDestroyOnLoad(gameObject);

        board = GetComponent<TileAutomata>();
        InitGame();
    }

    void InitGame()
    {
        board.SceneSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
