using UnityEngine;
using System.Collections;

public class ArcanoidManager : MonoBehaviour
{
    public int lives = 4;
    public int score = 0;

    ArkanoidBall ball;
    //Bat player;

    public float defaultSpeed;
    public int points;

    void Start()
    {
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
    }
}
