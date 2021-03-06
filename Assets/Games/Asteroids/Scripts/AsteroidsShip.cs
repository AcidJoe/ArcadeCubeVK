﻿using UnityEngine;
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
    public Animator anim;

    public bool outOfLife;

    AstroSounds sound;

    void Start()
    {
        sound = FindObjectOfType<AstroSounds>();
        outOfLife = false;
        cooldown = 0.0f;
        rb = GetComponent<Rigidbody2D>();
        Ship_collider = GetComponent<PolygonCollider2D>();
        anim = GetComponent<Animator>();
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

    void OnEnable()
    {
        AsteroidEvent.crashed += Crash;
        AsteroidEvent.gameOver += GameOver;
    }

    void OnDisable()
    {
        AsteroidEvent.crashed -= Crash;
        AsteroidEvent.gameOver -= GameOver;
    }

    void Crash()
    {
        StartCoroutine(_Crash());
    }

    void GameOver()
    {
        sound.GameOver();
        Destroy(gameObject);
    }

    IEnumerator _Crash()
    {
        sound.Lose();
        rb.velocity = Vector3.zero;
        transform.position = Vector3.zero;
        Ship_collider.enabled = false;
        anim.SetBool("isInvisible", true);
        yield return new WaitForSeconds(2.3f);
        anim.SetBool("isInvisible", false);
        Ship_collider.enabled = true;
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
