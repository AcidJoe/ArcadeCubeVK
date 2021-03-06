﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeManager : MonoBehaviour
{
    public List<SnakeFood> food;

    public GameObject snakeFood;

    SnakePoolManager spm;
    Snake snake;

    public int score;

    public int collectedFood;

    public ColorElement[] colorElements;

    void Start ()
    {
        collectedFood = 0;
        spm = FindObjectOfType<SnakePoolManager>();
        snake = FindObjectOfType<Snake>();
        food = new List<SnakeFood>();
    }
	
	void Update ()
    {
        colorElements = FindObjectsOfType<ColorElement>();

        if (spm.isReady && !snake.isStart)
        {
            snake.startMove();
        }
        if (food.Count < 1)
        {
            SpawnFood(foodSpawnPoint());
        }

        if(collectedFood >= 10)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        if (GameInfo.difficulty < 6)
        {
            EventManager.OnGameEnd();
            GameInfo.difficulty++;
            DifficultyManager.Settings();
            DifficultyManager.SetDiffName();
            EventManager.OnStartGame();

            foreach (ColorElement c in colorElements)
            {
                c.isPainted = false;
                c.Repaint();
            }
        }

        else
        {
            EventManager.OnGameEnd();
            GameInfo.extraRound++;
            DifficultyManager.ExtraSettings();
            EventManager.OnStartGame();
        }

        snake.spawnTime = DifficultyManager.snakespeed;
        if (Input.GetKey(KeyCode.Space))
        {
            snake.spawnTime /= 3;
        }
        collectedFood = 0;
    }

    void SpawnFood(Vector2 v)
    {
        var newFood = Instantiate(snakeFood, v, Quaternion.identity);
        food.Add(newFood as SnakeFood);
    }

    Vector2 ran()
    {
        int x = Random.Range(-15, 15);
        int y = Random.Range(-10, 10);

        return new Vector2(x, y);
    }

    bool Check(Vector2 vec)
    {
        if (Physics2D.OverlapCircle(vec, 0.2f))
        {
            return true;
        }

        return false;
    }

    Vector2 foodSpawnPoint()
    {
        Vector2 vec = ran();
        while (Check(vec))
        {
            vec = ran();
        }

        return vec;
    }
}
