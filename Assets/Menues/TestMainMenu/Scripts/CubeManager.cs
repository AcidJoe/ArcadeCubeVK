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

    bool isReadyToChoose;

    void Start()
    {
        isReadyToChoose = false;
        Game.isReady = false;
        fillTimer = 2.3f;
        isRandomize = false;
        greatingsPanel.SetActive(true);
        randomizerPanel.SetActive(false);
    }

    void Update()
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
        EventManager.sInsert += SilverCoin;
        EventManager.gInsert += GoldCoin;
    }

    void OnDisable()
    {
        EventManager.bInsert -= BronzeCoin;
        EventManager.sInsert -= SilverCoin;
        EventManager.gInsert -= GoldCoin;
    }

    void BronzeCoin()
    {
        greatingsPanel.SetActive(false);
        randomizerPanel.SetActive(true);
        StartCoroutine(randomizer(0));
    }

    void SilverCoin()
    {
        isReadyToChoose = true;
    }

    void GoldCoin()
    {
        StartCoroutine(GoldIn());
    }

    IEnumerator GoldIn()
    {
        Randomizer.SetGame(0);
        SetNames(Game.currentGame, GameInfo.difficulty);
        Game.currengGameName = gameName;
        GameInfo.diffName = diffName;
        isRandomize = false;
        Game.isReady = true;
        yield return new WaitForSeconds(0.2f);
        greatingsPanel.SetActive(false);
        randomizerPanel.SetActive(true);
    }

    IEnumerator randomizer(int i)
    {
        Randomizer.SetGame(i);
        isRandomize = true;
        switch (i)
        {
            case 0:
                randomGame();
                randomDiff();
                break;
            case 1:
                randomGame();
                break;
            case 2:
                randomDiff();
                break;
        }
        yield return new WaitForSeconds(2.3f);
        SetNames(Game.currentGame, GameInfo.difficulty);
        Game.currengGameName = gameName;
        GameInfo.diffName = diffName;
        isRandomize = false;
        Game.isReady = true;
        fillTimer = 0;
    }

    void randomGame()
    {
        gameID = Random.Range(1, 5);

        SetNames(gameID, GameInfo.difficulty);

        if (isRandomize)
        {
            Invoke("randomGame", timer);
            timer += 0.002f;
        }
    }

    void randomDiff()
    {
        DiffID = Random.Range(1, 6);

        SetNames(Game.currentGame, DiffID);

        if (isRandomize)
        {
            Invoke("randomDiff", timer);
            timer += 0.002f;
        }
    }

    public void SilverActivated(int i)
    {
        if (isReadyToChoose)
        {
            StartCoroutine(randomizer(i));
            isReadyToChoose = false;
        }
    }

    public void GoldButtonGame()
    {
        Game.currentGame++;
        if (Game.currentGame > 5)
        {
            Game.currentGame = 1;
        }
        SetNames(Game.currentGame, GameInfo.difficulty);
        Game.currengGameName = gameName;
    }

    public void GoldButtonDiff()
    {
        GameInfo.difficulty++;
        if (GameInfo.difficulty > 6)
        {
            GameInfo.difficulty = 1;
        }
        SetNames(Game.currentGame, GameInfo.difficulty);
        GameInfo.diffName = diffName;
        Randomizer.SetToDiffMan();
    }

    void SetNames(int gid, int did)
    {
        switch (gid)
        {
            case 1:
                gameName = "Арканоид";
                break;
            case 2:
                gameName = "Астеройды";
                break;
            case 3:
                gameName = "Понг";
                break;
            case 4:
                gameName = "Змейка";
                break;
            case 5:
                gameName = "Тетрис";
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
