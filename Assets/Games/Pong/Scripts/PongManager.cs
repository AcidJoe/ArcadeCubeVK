using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PongManager : MonoBehaviour
{
    PongBall ball;

    float default_speed;
    int dir;

    public int playerScore;
    public int AIscore;

    public Text pscore;
    public Text aiscore;

	void Start ()
    {
        playerScore = 0;
        AIscore = 0;
        dir = 0;
        default_speed = DifficultyManager.pongBallSpeed;
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<PongBall>();

        if(DifficultyManager.pongBallSpeed == 0)
        {
            default_speed = 10;
        } 
        StartCoroutine(startGame());
	}
	
	void Update ()
    {
        pscore.text = playerScore.ToString();
        aiscore.text = AIscore.ToString();
        Goal();
	}

    public void Goal()
    {
        if (ball)
        {
            if(ball.transform.position.x > 15)
            {
                dir = -1;
                AIscore++;
                goalSettings();
            }
            else if (ball.transform.position.x < -15)
            {
                dir = 1;
                playerScore++;
                goalSettings();
            }
        }
    }

    public IEnumerator startGame()
    {
        yield return new WaitForSeconds(1);

        goalSettings();
    }

    int randDir()
    {
        int i = 0;
        while(i == 0)
        {
            i = Random.Range(-1, 1);
        }
        return i;
    }

    float ranY()
    {
        float y;
        y = Random.Range(-0.2f, 0.2f);
        return y;
    }

    void goalSettings()
    {
        if (dir == 0)
            dir = randDir();

        ball.transform.position = Vector2.zero;
        ball.rb.velocity = Vector2.zero;
        ball.speed = default_speed;

        ball.rb.velocity = (new Vector3(dir, ranY()) - ball.transform.position).normalized * ball.speed;
    }
}
