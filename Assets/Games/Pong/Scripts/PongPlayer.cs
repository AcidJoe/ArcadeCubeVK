using UnityEngine;
using System.Collections;

public class PongPlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float dir = Input.GetAxis("Vertical");

        rb.velocity = (new Vector2(0, dir)) * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Border")
        {
            rb.velocity = (new Vector3(0, 0, 0) * Time.deltaTime);
        }
    }
}
