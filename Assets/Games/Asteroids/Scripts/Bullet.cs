using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;

    public AsteroidsShip ship; 

    float lifetime;

	void Awake()
    {
        lifetime = 1.5f;
        rb = GetComponent<Rigidbody2D>();
        ship = GameObject.FindGameObjectWithTag("Player").GetComponent<AsteroidsShip>();

        rb.AddForce(ship.transform.up * 600.0f);
    }

    void Update()
    {
        lifetime -= Time.deltaTime;

        if(lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
