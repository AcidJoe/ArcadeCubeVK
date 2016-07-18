using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public static TestMainMenu manager;
    public delegate void CoinInsert();
    public delegate void StartGame();
    public delegate void EndGame();

    public static event CoinInsert bInsert;
    public static event CoinInsert sInsert;
    public static event CoinInsert gInsert;

    public static event StartGame startGame;
    public static event EndGame endGame;
    public static event EndGame toMenu;

    void Start ()
    {
        manager = FindObjectOfType<TestMainMenu>();
	}
	
	void Update ()
    {
	
	}

    public static void OnInsert(string type)
    {
        switch (type)
        {
            case "b":
                if (!manager.isBronzeIn)
                {
                    bInsert();
                }
                break;
            case "s":
                if (manager.isBronzeIn && !manager.isSilverIn)
                {
                    sInsert();
                }
                break;
            case "g":
                if (!manager.isGoldIn)
                {
                    gInsert();
                }
                break;
        }
    }

    public static void OnStartGame()
    {
        startGame();
    }

    public static void OnGameEnd()
    {
        endGame();
    }

    public static void OnMenuBack()
    {
        toMenu();
    }
}
