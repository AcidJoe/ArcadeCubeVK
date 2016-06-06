﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TetrisUI : MonoBehaviour
{
    TetrisManager gameManager;

    public Text score;
    public Text diff;

    void Start()
    {
        gameManager = FindObjectOfType<TetrisManager>();
    }

    void Update()
    {
        score.text = currentScore(gameManager.score);
        diff.text = GameInfo.diffName;
    }

    public string currentScore(int i)
    {
        if (i <= 9)
        {
            return "000" + i.ToString();
        }

        else if (i > 9 && i <= 99)
        {
            return "00" + i.ToString();
        }

        else if (i > 99 && i <= 999)
        {
            return "0" + i.ToString();
        }

        return i.ToString();
    }
}