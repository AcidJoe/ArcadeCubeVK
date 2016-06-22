using UnityEngine;
using System.Collections;

public class AsteroidSmall : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 dir;

    float speed;
    float difficultyMod;

    AsteroidsManager astroMan;

    public AsteroidsShip playerShip;

    void Awake()
    {
        astroMan = FindObjectOfType<AsteroidsManager>();

        rb = GetComponent<Rigidbody2D>();

        dir = new Vector2(transform.position.x, transform.position.y) - new Vector2(Random.Range(-1000, 1000), Random.Range(-1000, 1000));

        dir = dir.normalized;

        difficultyMod = DifficultyManager.astroSpeedMod;

        playerShip = GameObject.FindGameObjectWithTag("Player").GetComponent<AsteroidsShip>();     

        speed = Random.Range(1.2f, 1.5f);

        rb.velocity = dir * speed * difficultyMod;
    }

    void Update()
    {

    }

    void Crack()
    {
        astroMan.score += DifficultyManager.astroPoints;
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
            AsteroidEvent.OnCrash();
        }
    }
}
