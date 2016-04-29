using UnityEngine;
using System.Collections;

public class PongAI : MonoBehaviour
{
    public GameObject Ball;
    private Transform CurrentTransform;
    public int speed;

    public Rigidbody2D rb;

    void Start()
    {
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
        if (Ball)
        {
            if (CurrentTransform.position.x < Ball.transform.position.x)
            {
                if (CurrentTransform.position.y < Ball.transform.position.y)
                {
                    rb.velocity = new Vector2(0, 1) * speed;
                }
                else if (CurrentTransform.position.y > Ball.transform.position.y)
                {
                    rb.velocity = new Vector2(0, -1) * speed;
                }
                else {
                    rb.velocity = new Vector2(0, 0) * speed;
                }
            }
        }
    }
}
