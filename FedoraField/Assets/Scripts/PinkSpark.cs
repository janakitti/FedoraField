﻿using System.Collections;
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
        tanVel = 2f;
        rb = GetComponent<Rigidbody2D>();
        pinkBulletCollider = GetComponent<Collider2D>();
        bulletSpeed = 100.0f;
        rb.AddForce(Vector2.up * bulletSpeed);
        canKillEnemy = false;
    }


    void Update()
    {
        if (Player.isUsingField == 1)
        {
            if (Vector2.Distance(transform.position, GameObject.Find("player").transform.position) < 7)
            {
                rb.AddForce((transform.position - GameObject.Find("player").transform.position) * -centAcc);
                rb.velocity = Vector2.Perpendicular(transform.position - GameObject.Find("player").transform.position) * tanVel;
                transform.gameObject.tag = "Projectile";
            }
        }
        else
        {
            rb.AddForce(Vector3.zero);
        }

        /*
        if (rb.IsTouching(Player.playerCollider) || rb.IsTouching(PinkEnemy.cd) || rb.IsTouching(Wall.wallCollider))
        {
            Destroy(gameObject);
        }
        */
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
