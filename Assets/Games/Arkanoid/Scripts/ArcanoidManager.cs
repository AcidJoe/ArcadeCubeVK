using UnityEngine;
using System.Collections;

public class ArcanoidManager : MonoBehaviour
{
    public int lives;
    public int score = 0;

    ArkanoidBall ball;
    //Bat player;

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<ArkanoidBall>();
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Bat>();
    }

    void Update()
    {
        if (ball.transform.position.y < -10.0f)
        {
            ball.isActivate = false;
        }
    }
}
