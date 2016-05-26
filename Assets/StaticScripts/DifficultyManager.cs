using UnityEngine;
using System.Collections;

public static class DifficultyManager
{
    public enum Game { Asteroids, Arkanoid, Pong, Snake, Tetris, Unset }

    public static Game currentGame = Game.Unset;

    public static float arkspeed;
    public static int arkpoints;

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
        }
    }

    public static void SetGame(Game game)
    {
        currentGame = game;
    }
}
