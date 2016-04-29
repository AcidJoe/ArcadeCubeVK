using UnityEngine;
using System.Collections;

public class PongBall : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * speed;
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
        }
    }
}
