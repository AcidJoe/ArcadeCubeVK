using UnityEngine;
using System.Collections;

public class TetrisEvents : MonoBehaviour
{
    public delegate void GameOver();

    public static GameOver gameOver;

    public static void OnGameOver()
    {
        gameOver();
    }

}
