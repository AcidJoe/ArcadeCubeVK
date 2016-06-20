using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CubeManager : MonoBehaviour
{
    public GameObject greatingsPanel;
    public GameObject randomizerPanel;

    public Text game;
    public Text diff;
    public Image fill;

    public float fillTimer;

    public int gameID;
    public int DiffID;

    public string gameName;
    public string diffName;

    public float timer = 0.001f;
    public bool isRandomize;

    void Start ()
    {
        Game.isReady = false;
        fillTimer = 2.3f;
        isRandomize = false;
        greatingsPanel.SetActive(true);
        randomizerPanel.SetActive(false);
	}
	
	void Update ()
    {
        fill.fillAmount = fillTimer / 2.3f;

        if (isRandomize)
        {
            game.text = gameName;
            diff.text = diffName;
            fillTimer -= Time.deltaTime;
        }
        else
        {
            game.text = Game.currengGameName;
            diff.text = GameInfo.diffName;
        }
	}

    void OnEnable()
    {
        EventManager.bInsert += BronzeCoin;
    }

    void OnDisable()
    {
        EventManager.bInsert -= BronzeCoin;
    }

    void BronzeCoin()
    {
        greatingsPanel.SetActive(false);
        randomizerPanel.SetActive(true);
        StartCoroutine(randomizer());
    }

    IEnumerator randomizer()
    {
        isRandomize = true;
        random();
        yield return new WaitForSeconds(2.3f);
        isRandomize = false;
        switch (gameID)
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
        Game.isReady = true;
        fillTimer = 0;
    }

    void random()
    {
        gameID = Random.Range(1, 5);
        DiffID = Random.Range(1, 6);

        SetNames(gameID, DiffID);

        if (isRandomize)
        {
            Invoke("random", timer);
            timer += 0.002f;
        }

        GameInfo.difficulty = DiffID;
        GameInfo.diffName = diffName;
        Game.currentGame = gameID;
        Game.currengGameName = gameName;
        SetNames(Game.currentGame, GameInfo.difficulty);
    }

    void SetNames(int gid, int did)
    {
        switch (gid)
        {
            case 1:
                gameName = "Арканоид";
                DifficultyManager.SetGame(DifficultyManager.Game.Arkanoid);
                break;
            case 2:
                gameName = "Астеройды";
                DifficultyManager.SetGame(DifficultyManager.Game.Asteroids);
                break;
            case 3:
                gameName = "Понг";
                DifficultyManager.SetGame(DifficultyManager.Game.Pong);
                break;
            case 4:
                gameName = "Змейка";
                DifficultyManager.SetGame(DifficultyManager.Game.Snake);
                break;
            case 5:
                gameName = "Тетрис";
                DifficultyManager.SetGame(DifficultyManager.Game.Tetris);
                break;
        }

        switch (did)
        {
            case 1:
                diffName = "Очень легко";
                break;
            case 2:
                diffName = "Легко";
                break;
            case 3:
                diffName = "Средне";
                break;
            case 4:
                diffName = "Сложно";
                break;
            case 5:
                diffName = "Очень сложно";
                break;
            case 6:
                diffName = "Хардкор";
                break;
        }
    }
}
