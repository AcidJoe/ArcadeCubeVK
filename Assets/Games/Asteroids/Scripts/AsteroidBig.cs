using UnityEngine;
using System.Collections;

public class AsteroidBig : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 dir;

    public AsteroidsShip playerShip;

    float speed;

    public Transform player;

    public GameObject astermid1;
    public GameObject astermid2;
    public GameObject astermid3;
    public GameObject astermid4;

    void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        playerShip = player.GetComponent<AsteroidsShip>();

        dir = new Vector2 (transform.position.x, transform.position.y) - new Vector2(player.position.x + Random.Range(-12,12), player.position.y + Random.Range(-12, 12));

        dir = dir.normalized;

        speed = Random.Range(0.7f, 1.0f);

        rb.velocity = dir * speed;
	}
	
	void Update ()
    {
	
	}

    GameObject ranAster()
    {
        int i = Random.Range(1, 4);

        switch (i)
        {
            case 1:
                return astermid1;
            case 2:
                return astermid2;
            case 3:
                return astermid3;
            case 4:
                return astermid4;
        }

        return astermid1;
    }

    void Crack()
    {
        Instantiate(ranAster(), transform.position, Quaternion.identity);
        Instantiate(ranAster(), transform.position, Quaternion.identity);
        Instantiate(ranAster(), transform.position, Quaternion.identity);
        
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            Crack();
        }

        if(col.gameObject.tag == "Player")
        {
            
        }
    }
}
