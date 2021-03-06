﻿using UnityEngine;
using System.Collections;

public static class DifficultyManager
{
    public enum Game { Asteroids, Arkanoid, Pong, Snake, Tetris, Unset }

    public static Game currentGame = Game.Unset;

    //Arkanoid
    public static float arkspeed;
    public static int arkpoints;
    //Snake
    public static float snakespeed;
    public static int snakepoints;
    //Pong
    public static float pongAIspeed;
    public static float pongBallSpeed;
    public static float pongstupmin;
    public static float pongstupmax;
    public static float pongstuptime;
    public static int pongchance;
    public static float pongtimer;
    //Tetris
    public static float tetrisfallspeed;
    public static int tetrispoints;
    //Asteroids
    public static float astroSpeedMod;
    public static int astroCount;
    public static int astroPoints;

    public static void Settings()
    {
        switch (currentGame)
        {
            #region "Arkanoid"
            case Game.Arkanoid:
                switch (GameInfo.difficulty)
                {
                    case 1:
                        arkspeed = 10;
                        arkpoints = 1;
                        break;
                    case 2:
                        arkspeed = 15;
                        arkpoints = 1;
                        break;
                    case 3:
                        arkspeed = 20;
                        arkpoints = 2;
                        break;
                    case 4:
                        arkspeed = 25;
                        arkpoints = 2;
                        break;
                    case 5:
                        arkspeed = 30;
                        arkpoints = 3;
                        break;
                    case 6:
                        arkspeed = 40;
                        arkpoints = 5;
                        break;
                }
                break;
            #endregion
            #region "Snake"
            case Game.Snake:
                switch (GameInfo.difficulty)
                {
                    case 1:
                        snakespeed = 0.5f;
                        snakepoints = 1;
                        break;
                    case 2:
                        snakespeed = 0.4f;
                        snakepoints = 2;
                        break;
                    case 3:
                        snakespeed = 0.2f;
                        snakepoints = 2;
                        break;
                    case 4:
                        snakespeed = 0.2f;
                        snakepoints = 3;
                        break;
                    case 5:
                        snakespeed = 0.1f;
                        snakepoints = 3;
                        break;
                    case 6:
                        snakespeed = 0.05f;
                        snakepoints = 4;
                        break;
                }
                break;
            #endregion
            #region "Pong"
            case Game.Pong:
                switch (GameInfo.difficulty)
                {
                    case 1:
                        pongAIspeed = 7;
                        pongBallSpeed = 17;
                        pongstupmin = 1;
                        pongstupmax = 3;
                        pongstuptime = 2;
                        pongchance = 30;
                        pongtimer = 1;
                        break;
                    case 2:
                        pongAIspeed = 8;
                        pongBallSpeed = 20;
                        pongstupmin = 0.3f;
                        pongstupmax = 1;
                        pongstuptime = 2;
                        pongchance = 30;
                        pongtimer = 1;
                        break;
                    case 3:
                        pongAIspeed = 10;
                        pongBallSpeed = 25;
                        pongstupmin = 0.3f;
                        pongstupmax = 1;
                        pongstuptime = 2;
                        pongchance = 30;
                        pongtimer = 1;
                        break;
                    case 4:
                        pongAIspeed = 11;
                        pongBallSpeed = 30;
                        pongstupmin = 0.3f;
                        pongstupmax = 1;
                        pongstuptime = 2;
                        pongchance = 30;
                        pongtimer = 1;
                        break;
                    case 5:
                        pongAIspeed = 11;
                        pongBallSpeed = 32;
                        pongstupmin = 0.3f;
                        pongstupmax = 1;
                        pongstuptime = 2;
                        pongchance = 30;
                        pongtimer = 1;
                        break;
                    case 6:
                        pongAIspeed = 13;
                        pongBallSpeed = 35;
                        pongstupmin = 0.3f;
                        pongstupmax = 1;
                        pongstuptime = 2;
                        pongchance = 30;
                        pongtimer = 1;
                        break;
                }
                break;
            #endregion
            #region "Tetris"
            case Game.Tetris:
                switch (GameInfo.difficulty)
                {
                    case 1:
                        tetrisfallspeed = 1;
                        tetrispoints = 1;
                        break;
                    case 2:
                        tetrisfallspeed = 0.8f;
                        tetrispoints = 1;
                        break;
                    case 3:
                        tetrisfallspeed = 0.6f;
                        tetrispoints = 2;
                        break;
                    case 4:
                        tetrisfallspeed = 0.4f;
                        tetrispoints = 3;
                        break;
                    case 5:
                        tetrisfallspeed = 0.2f;
                        tetrispoints = 4;
                        break;
                    case 6:
                        tetrisfallspeed = 0.14f;
                        tetrispoints = 5;
                        break;
                }
                break;
            #endregion
            #region "Asteroids"
            case Game.Asteroids:
                switch (GameInfo.difficulty)
                {
                    case 1:
                        astroSpeedMod = 1.2f;
                        astroCount = 2;
                        astroPoints = 1;
                        break;
                    case 2:
                        astroSpeedMod = 1.4f;
                        astroCount = 2;
                        astroPoints = 2;
                        break;
                    case 3:
                        astroSpeedMod = 1.5f;
                        astroCount = 3;
                        astroPoints = 2;
                        break;
                    case 4:
                        astroSpeedMod = 1.7f;
                        astroCount = 3;
                        astroPoints = 3;
                        break;
                    case 5:
                        astroSpeedMod = 1.8f;
                        astroCount = 4;
                        astroPoints = 3;
                        break;
                    case 6:
                        astroSpeedMod = 2;
                        astroCount = 4;
                        astroPoints = 4;
                        break;
                }
                break;
                #endregion
        }
    }

    public static void SetGame(Game game)
    {
        currentGame = game;
    }

    public static void SetDiffName()
    {
        switch (GameInfo.difficulty)
        {
            case 1:
                GameInfo.diffName = "Очень легко";
                break;
            case 2:
                GameInfo.diffName = "Легко";
                break;
            case 3:
                GameInfo.diffName = "Средне";
                break;
            case 4:
                GameInfo.diffName = "Сложно";
                break;
            case 5:
                GameInfo.diffName = "Очень сложно";
                break;
            case 6:
                GameInfo.diffName = "Хардкор";
                break;
        }
    }

    public static void ExtraSettings()
    {
        switch (currentGame)
        {
            case Game.Arkanoid:
                arkspeed += 5;
                arkpoints += 1;
                break;
            case Game.Asteroids:
                astroSpeedMod += 0.5f;
                astroCount = 4;
                astroPoints += 1;
                break;
            case Game.Pong:
                break;
            case Game.Snake:
                snakespeed -= 0.01f;
                snakepoints++;
                break;
            case Game.Tetris:
                tetrisfallspeed -= 0.02f;
                tetrispoints++;
                break;
        }
    }
}
