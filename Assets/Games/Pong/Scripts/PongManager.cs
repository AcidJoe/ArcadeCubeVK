using UnityEngine;
using System.Collections;

public class PongManager : MonoBehaviour
{
    PongBall ball;

    float default_speed;
    int dir;

	void Start ()
    {
        default_speed = 20.0f;
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<PongBall>();
        StartCoroutine(startGame());
	}
	
	void Update ()
    {
        Goal();
	}

    public void Goal()
    {
        if (ball)
        {
            if(ball.transform.position.x > 15)
            {
                dir = -1;
                goalSettings();
            }
            else if (ball.transform.position.x < -15)
            {
                dir = 1;
                goalSettings();
            }
        }
    }

    public IEnumerator startGame()
    {
        yield return new WaitForSeconds(2);

        StartGame();
    }

    void StartGame()
    {
        ball.transform.position = Vector2.zero;
        ball.speed = default_speed;
        ball.rb.velocity = new Vector2(randDir(), 0) * ball.speed;
    }

    int randDir()
    {
        int i = 0;
        while(i == 0)
        {
            i = Random.Range(-1, 1);
        }
        dir = i;
        return i;
    }

    float ranY()
    {
        float y;
        y = Random.Range(-1, 1);
        return y;
    }

    void goalSettings()
    {
        ball.transform.position = Vector2.zero;
        ball.rb.velocity = Vector2.zero;
        ball.speed = default_speed;

        ball.rb.velocity = (new Vector3(dir, ranY()) - ball.transform.position).normalized * ball.speed;
    }
}
