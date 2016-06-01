using UnityEngine;
using System.Collections;

public class PongAI : MonoBehaviour
{
    public GameObject Ball;
    private Transform CurrentTransform;
    public float speed;
    public float default_speed;
    public float target;
    public float stupidfactor;

    public bool isStupid;
    public float stupidTimer;
    public float timer_default;

    public float stupmin, stupmax, stupMaxTime;

    public int chance;

    public Rigidbody2D rb;

    void Start()
    {
        stupmin = DifficultyManager.pongstupmin;
        stupmax = DifficultyManager.pongstupmax;
        stupMaxTime = DifficultyManager.pongstuptime;
        timer_default = DifficultyManager.pongtimer;
        chance = DifficultyManager.pongchance;
        isStupid = false;
        stupidTimer = timer_default;
        default_speed = DifficultyManager.pongAIspeed;
        speed = default_speed;
        rb = GetComponent<Rigidbody2D>();
        CurrentTransform = transform;
    }

    void Update()
    {
        stupidTimer -= Time.deltaTime;

        if (!Ball)
        {
            Ball = GameObject.FindGameObjectWithTag("Ball");
        }

        else if(Ball)
        {
            target = Ball.transform.position.y + stupidfactor;
        }

        if (!isStupid && stupidTimer <= 0)
        {
            TryStupidity();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CurrentTransform = transform;
        float step = 0.2f;

        if (Ball)
        {
            float dist = Mathf.Abs(Ball.transform.position.y - CurrentTransform.position.y);

            if (CurrentTransform.position.x < Ball.transform.position.x)
            {
                if(dist < 0.4)
                {
                    speed *= dist;
                }
                else
                {
                    speed = default_speed;
                }

                if (CurrentTransform.position.y < target && dist > step)
                {
                    rb.velocity = Vector2.up * speed;
                }
                else if (CurrentTransform.position.y > target && dist > step)
                {
                    rb.velocity = Vector2.down * speed;
                }
                else if (dist< step)
                {
                    rb.velocity = Vector2.zero * speed;
                }
            }
        }
    }

    void Stupidity(float min, float max)
    {
        float ran = Random.Range(min, max);
        stupidfactor = ran;
    }

    void Normalize()
    {
        stupidfactor = 0;
    }

    void TryStupidity()
    {
        int ran = Random.Range(0, 100);

        if(ran > chance)
        {
            Normalize();
        }

        else if(ran <= chance)
        {
            StartCoroutine(StartStupidity());
        }
    }

    IEnumerator StartStupidity()
    {
        Stupidity(stupmin, stupmax);
        isStupid = true;
        float ran = Random.Range(0.2f, stupMaxTime);

        yield return new WaitForSeconds(ran);

        isStupid = false;
        stupidTimer = timer_default;
        Normalize();
    }
}
