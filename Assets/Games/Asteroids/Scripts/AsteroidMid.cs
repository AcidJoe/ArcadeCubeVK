using UnityEngine;
using System.Collections;

public class AsteroidMid : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 dir;

    float speed;
    float difficultyMod;

    public AsteroidsShip playerShip;

    AsteroidsManager astroMan;

    public GameObject astersm1;
    public GameObject astersm2;
    public GameObject astersm3;
    public GameObject astersm4;

    void Awake()
    {
        astroMan = FindObjectOfType<AsteroidsManager>();

        rb = GetComponent<Rigidbody2D>();

        dir = new Vector2(transform.position.x, transform.position.y) - new Vector2(Random.Range(-1000, 1000), Random.Range(-1000, 1000));

        dir = dir.normalized;

        difficultyMod = DifficultyManager.astroSpeedMod;

        playerShip = GameObject.FindGameObjectWithTag("Player").GetComponent<AsteroidsShip>();

        speed = Random.Range(1.0f, 1.3f);

        rb.velocity = dir * speed * difficultyMod;
    }

    void Update()
    {

    }

    GameObject ranAster()
    {
        int i = Random.Range(1, 4);

        switch (i)
        {
            case 1:
                return astersm1;
            case 2:
                return astersm2;
            case 3:
                return astersm3;
            case 4:
                return astersm4;
        }

        return astersm1;
    }

    void Crack()
    {
        astroMan.score += DifficultyManager.astroPoints * 2;

        Instantiate(ranAster(), transform.position, Quaternion.identity);
        Instantiate(ranAster(), transform.position, Quaternion.identity);
        Instantiate(ranAster(), transform.position, Quaternion.identity);

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
