﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidsManager : MonoBehaviour
{
    public int lives = 4;
    public int score;

    public Vector3 spawn_point_1;
    public Vector3 spawn_point_2;
    public Vector3 spawn_point_3;
    public Vector3 spawn_point_4;

    public GameObject asterbig1;
    public GameObject asterbig2;
    public GameObject asterbig3;
    public GameObject asterbig4;

    public bool isStart;
    public bool spawned;

    public int astroCount;
    public Stack<int> points;

    public GameObject[] astros;

    void Start()
    {
        score = GameInfo.saveResult;
        lives = GameInfo.saveLives;

        spawned = false;
        isStart = false;
        points = new Stack<int>();

        astroCount = DifficultyManager.astroCount;

        spawn_point_1 = new Vector3(-18, Random.Range(-1, 1));
        spawn_point_2 = new Vector3(18, Random.Range(-1, 1));
        spawn_point_3 = new Vector3(Random.Range(-1,1), 11);
        spawn_point_4 = new Vector3(Random.Range(-1, 1), -11);
    }
	
	void Update ()
    {
        if (!isStart && astroCount < 4)
        {
            fillStack(astroCount);
            isStart = true;
        }
        else if(!isStart && astroCount == 4)
        {
            points.Push(1);
            points.Push(2);
            points.Push(3);
            points.Push(4);

            isStart = true;
        }
        else if(isStart && !spawned)
        {
            Spawn();
            spawned = true;
        }

        astros = GameObject.FindGameObjectsWithTag("Astro");

        if(astros.Length <= 0 && spawned)
        {
            if(GameInfo.difficulty < 6)
            {
                EventManager.OnGameEnd();
                GameInfo.difficulty++;
                DifficultyManager.Settings();
                GameInfo.saveResult = score;
                GameInfo.saveLives = lives;
                DifficultyManager.SetDiffName();
                TestSceneManager.LoadScene(Game.currentGame);
                EventManager.OnStartGame();
            }

            else
            {
                LevelUp();
            }
        }
	}

    void OnEnable()
    {
        AsteroidEvent.crashed += Crash;
    }

    void OnDisable()
    {
        AsteroidEvent.crashed -= Crash;
    }

    void Crash()
    {
        lives--;
        if(lives <= 0)
        {
            AsteroidEvent.OnGameOver();
        }
    }

    void LevelUp()
    {
        EventManager.OnGameEnd();
        GameInfo.extraRound++;
        DifficultyManager.ExtraSettings();
        GameInfo.saveResult = score;
        GameInfo.saveLives = lives;
        TestSceneManager.LoadScene(Game.currentGame);
        EventManager.OnStartGame();
    }

    void fillStack(int count)
    {
        for(int i = 0; i < count; i++)
        {
            int ran = Random.Range(1,4);

            while (!checkPoint(ran))
            {
                ran = Random.Range(1, 4);
            }

            points.Push(ran);
        }
    }

    bool checkPoint(int i)
    {
        foreach(int point in points)
        {
            if (point == i)
                return false;
        }

        return true;
    }

    void Spawn()
    {
        foreach(int i in points)
        {
            Instantiate(ranAster(), spawnPoint(i), Quaternion.identity);
        }
    }

    GameObject ranAster()
    {
        int i = Random.Range(1, 4);

        switch (i)
        {
            case 1:
                return asterbig1;
            case 2:
                return asterbig2;
            case 3:
                return asterbig3;
            case 4:
                return asterbig4;
        }

        return asterbig1;
    }

    Vector3 spawnPoint(int i)
    {
        switch (i)
        {
            case 1:
                return spawn_point_1;
            case 2:
                return spawn_point_2;
            case 3:
                return spawn_point_3;
            case 4:
                return spawn_point_4;
        }

        return spawn_point_1;
    }
}
