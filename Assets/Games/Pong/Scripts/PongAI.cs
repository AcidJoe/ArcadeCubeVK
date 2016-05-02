using UnityEngine;
using System.Collections;

public class PongAI : MonoBehaviour
{
    public GameObject Ball;
    private Transform CurrentTransform;
    public float speed;
    public float default_speed;

    public Rigidbody2D rb;

    void Start()
    {
        default_speed = 10;
        speed = default_speed;
        rb = GetComponent<Rigidbody2D>();
        CurrentTransform = transform;
    }

    void Update()
    {
        if (!Ball)
        {
            Ball = GameObject.FindGameObjectWithTag("Ball");
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

                if (CurrentTransform.position.y < Ball.transform.position.y && dist > step)
                {
                    rb.velocity = Vector2.up * speed;
                }
                else if (CurrentTransform.position.y > Ball.transform.position.y && dist > step)
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
}
