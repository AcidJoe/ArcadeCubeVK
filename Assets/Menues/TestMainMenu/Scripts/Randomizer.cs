using UnityEngine;
using System.Collections;

public class Randomizer : MonoBehaviour
{
    public static void SetGame(int i)
    {
        int ranGame = Random.Range(0, 100);
        int ranDiff = Random.Range(1, 6);

        if(ranGame > 0 && ranGame <= 20)
        {
            ranGame = 1;
        }
        else if (ranGame > 20 && ranGame <= 40)
        {
            ranGame = 2;
        }
        else if (ranGame > 40 && ranGame <= 60)
        {
            ranGame = 3;
        }
        else if (ranGame > 60 && ranGame <= 80)
        {
            ranGame = 4;
        }
        else if (ranGame > 80 && ranGame <= 100)
        {
            ranGame = 5;
        }

        if (i == 0)
        {
            Game.currentGame = ranGame;
            GameInfo.difficulty = ranDiff;
            SetToDiffMan();
        }
        else if(i == 1)
        {
            Game.currentGame = ranGame;
        }
        else if(i == 2)
        {
            GameInfo.difficulty = ranDiff;
            SetToDiffMan();
        }
    }

    public static void SetToDiffMan()
    {
        switch (Game.currentGame)
        {
            case 1:
                DifficultyManager.SetGame(DifficultyManager.Game.Arkanoid);
                break;
            case 2:
                DifficultyManager.SetGame(DifficultyManager.Game.Asteroids);
                break;
            case 3:
                DifficultyManager.SetGame(DifficultyManager.Game.Pong);
                break;
            case 4:
                DifficultyManager.SetGame(DifficultyManager.Game.Snake);
                break;
            case 5:
                DifficultyManager.SetGame(DifficultyManager.Game.Tetris);
                break;
        }
    }
}
