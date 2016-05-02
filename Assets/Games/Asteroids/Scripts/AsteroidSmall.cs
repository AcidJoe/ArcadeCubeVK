using UnityEngine;
using System.Collections;

public class AsteroidSmall : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 dir;

    float speed;

    public AsteroidsShip playerShip;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        dir = new Vector2(transform.position.x, transform.position.y) - new Vector2(Random.Range(-1000, 1000), Random.Range(-1000, 1000));

        dir = dir.normalized;

        playerShip = GameObject.FindGameObjectWithTag("Player").GetComponent<AsteroidsShip>();     

        speed = Random.Range(1.2f, 1.5f);

        rb.velocity = dir * speed;
    }

    void Update()
    {

    }

    void Crack()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            Crack();
        }

        if (col.gameObject.tag == "Player")
        {
            
        }
    }
}
