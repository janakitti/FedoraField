using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkSpark : PinkProjectile
{
    Rigidbody2D rb;
    public static Collider2D pinkBulletCollider;

    public float bulletSpeed;
    public float pinkBulletAcceleration;
    Vector2 moveDirection;
    public float centAcc;
    public float tanVel;
    public static bool canKillEnemy;

    private int gravityTick;

    // Use this for initialization
    void Start()
    {
        gravityTick = 0;
        InvokeRepeating("GravityClock", 0f, 0.1f);
        

        damage = 3;
        centAcc = 25f;
        tanVel = 0f;
        rb = GetComponent<Rigidbody2D>();
        pinkBulletCollider = GetComponent<Collider2D>();
        Destroy(gameObject, 10f);
        bulletSpeed = 100.0f;
        rb.AddForce(Vector2.up * bulletSpeed);
        canKillEnemy = false;
    }

    void Update()
    {
        if (Input.GetButton("X360_Y") && Player.fieldState == 1)
        {
            centAcc = gravityTick * 5;
            tanVel = gravityTick; // get current velocity of nullet and add from there
            rb.AddForce((transform.position - GameObject.Find("player").transform.position) * -(centAcc/10));
            rb.velocity = Vector2.Perpendicular(transform.position - GameObject.Find("player").transform.position) * (tanVel/10);
            transform.gameObject.tag = "Projectile";
        }
        else
        {
            gravityTick = 0;
            tanVel = 0f;
            centAcc = 0f;
            rb.AddForce(Vector3.zero);
        }
    }

    void GravityClock()
    {
        gravityTick++;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}
