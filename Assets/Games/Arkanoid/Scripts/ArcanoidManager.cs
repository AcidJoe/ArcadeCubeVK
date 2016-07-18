using UnityEngine;
using System.Collections;

public class ArcanoidManager : MonoBehaviour
{
    public int lives;
    public int score = 0;

    ArkanoidBall ball;
    ArcanoidLevelManager lm;

    public GameObject[] bricks;

    public float defaultSpeed;
    public int points;

    void Start()
    {
        score = GameInfo.saveResult;
        lives = GameInfo.saveLives;
        lm = FindObjectOfType<ArcanoidLevelManager>();
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<ArkanoidBall>();
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Bat>();
        defaultSpeed = DifficultyManager.arkspeed;
        points = DifficultyManager.arkpoints;
        ball.speed = defaultSpeed;
    }

    void Update()
    {
        if (ball.transform.position.y < -10.0f)
        {
            lives -= 1;
            ball.isActivate = false;
            ball.speed = defaultSpeed;
        }

        if (lm.isLevelCreated)
        {
            bricks = GameObject.FindGameObjectsWithTag("Brick");

            if(bricks.Length <= 0)
            {
                LevelUp();
                lm.isLevelCreated = false;
            }
        }
    }

    public void GameOver()
    {
        foreach(GameObject b in bricks)
        {
            b.transform.position = new Vector3(1000, 1000, -50000);
        }
        ball.transform.position = Vector3.zero;
        ball.speed = 0;
        ball.isActivate = true;
    }

    void LevelUp()
    {
        if (GameInfo.difficulty < 6)
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
            EventManager.OnGameEnd();
            GameInfo.extraRound++;
            DifficultyManager.ExtraSettings();
            GameInfo.saveResult = score;
            GameInfo.saveLives = lives;
            TestSceneManager.LoadScene(Game.currentGame);
            EventManager.OnStartGame();
        }
    }
}
