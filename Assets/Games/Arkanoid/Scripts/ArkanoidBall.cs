using UnityEngine;
using System.Collections;

public class ArkanoidBall : MonoBehaviour
{
    Rigidbody2D rb;

    public bool isActivate;

    public float speed;

    public GameObject player;

    public Vector3 pos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");

        isActivate = false;
    }

    void Update()
    {
        if (!isActivate && player != null)
        {
            pos.x = player.transform.position.x;
            pos.y = player.transform.position.y + 0.8f;

            transform.position = pos;
        }

        if (Input.GetButtonDown("Jump") && !isActivate)
        {
            isActivate = true;
            rb.velocity = (Vector2.up - (-Vector2.right/3)).normalized * speed;
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketWidth)
    {
        float f = (ballPos.x - racketPos.x) / racketWidth; ;
        // ascii art:
        //
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket
        //
        return f;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Hit the Racket?
        if (col.gameObject.tag == "Player")
        {
            // Calculate hit Factor
            float x = hitFactor(transform.position,
                              col.transform.position,
                              col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            speed += 0.5f;
        }
    }
}
