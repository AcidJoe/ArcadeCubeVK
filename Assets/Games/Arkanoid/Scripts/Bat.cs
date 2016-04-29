using UnityEngine;
using System.Collections;

public class Bat : MonoBehaviour
{
    public float playerVelocity;

    float h;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");

        rb.velocity = (new Vector3(h, 0, 0) * Time.deltaTime) * playerVelocity;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Border")
        {
            rb.velocity = (new Vector3(0, 0, 0) * Time.deltaTime) * playerVelocity;
        }
    }
}
