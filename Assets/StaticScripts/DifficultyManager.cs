﻿using UnityEngine;
using System.Collections;

public static class DifficultyManager
{
    public enum Game { Asteroids, Arkanoid, Pong, Snake, Tetris, Unset }

    public static Game currentGame = Game.Unset;

    public static float arkspeed;
    public static int arkpoints;

    public static float snakespeed;
    public static int snakepoints;

    public static float pongAIspeed;
    public static float pongBallSpeed;

    public static void Settings()
    {
        switch (currentGame)
        {
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
            case Game.Snake:
                switch (GameInfo.difficulty)
                {
                    case 1:
                        snakespeed = 0.5f;
                        snakepoints = 2;
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
                        snakepoints = 2;
                        break;
                    case 5:
                        snakespeed = 0.1f;
                        snakepoints = 2;
                        break;
                    case 6:
                        snakespeed = 0.05f;
                        snakepoints = 2;
                        break;
                }
                break;
            case Game.Pong:
                switch (GameInfo.difficulty)
                {
                    case 1:
                        pongAIspeed = 7;
                        pongBallSpeed = 17;
                        break;
                    case 2:
                        pongAIspeed = 8;
                        pongBallSpeed = 20;
                        break;
                    case 3:
                        pongAIspeed = 10;
                        pongBallSpeed = 25;
                        break;
                    case 4:
                        pongAIspeed = 11;
                        pongBallSpeed = 30;
                        break;
                    case 5:
                        pongAIspeed = 11;
                        pongBallSpeed = 32;
                        break;
                    case 6:
                        pongAIspeed = 13;
                        pongBallSpeed = 35;
                        break;
                }
                break;
        }
    }

    public static void SetGame(Game game)
    {
        currentGame = game;
    }
}
