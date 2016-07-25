using UnityEngine;
using System.Collections;

public class PongBall : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed;

    PongSound sound;

    void Start()
    {
        sound = FindObjectOfType<PongSound>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketWidth)
    {
        float f = (ballPos.y - racketPos.y) / racketWidth; ;
        // ascii art:
        //
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket
        //
        return f;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        sound.Bounce();

        // Hit the Racket?
        if (col.gameObject.tag == "Player")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                              col.transform.position,
                              col.collider.bounds.size.y);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            rb.velocity = dir * speed;
            speed += 0.5f;
        }

        if (col.gameObject.tag == "AI")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                              col.transform.position,
                              col.collider.bounds.size.y);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            rb.velocity = dir * speed;
            speed += 0.5f;
        }
    }
}
