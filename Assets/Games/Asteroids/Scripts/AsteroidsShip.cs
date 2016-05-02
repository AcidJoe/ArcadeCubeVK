using UnityEngine;
using System.Collections;

public class AsteroidsShip : MonoBehaviour
{
    Rigidbody2D rb;

    float hor;
    float vert;

    float cooldown;
    float invisibleTimer;

    public Transform gun;
    public GameObject bullet;

    public PolygonCollider2D Ship_collider;

    void Start()
    {
        cooldown = 0.0f;
        rb = GetComponent<Rigidbody2D>();
        Ship_collider = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        invisibleTimer -= Time.deltaTime;
        cooldown -= Time.deltaTime;

        if (invisibleTimer <= 0 && !Ship_collider.enabled)
        {
            Ship_collider.enabled = true;
        }

        hor = Input.GetAxis("Horizontal");
        vert = Mathf.Clamp(Input.GetAxis("Vertical"), 0, 1);

        Thrust();
        _Rotation();
        Fire();
    }

    void Thrust()
    {
        rb.AddForce(transform.up * vert * Time.deltaTime * 300.0f);
    }

    void _Rotation()
    {
        transform.Rotate(0, 0, -hor * Time.deltaTime * 100);
    }

    void Fire()
    {
        if (Input.GetKey(KeyCode.Space) && cooldown <= 0)
        {
            Instantiate(bullet, gun.position, transform.rotation);
            cooldown = 0.5f;
        }
    }
}
