using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempPinkBullet : PinkProjectile
{
    Rigidbody2D rb;
    public static Collider2D pinkBulletCollider;

    public float bulletSpeed;
    public float pinkBulletAcceleration;
    public GameObject target;
    Vector2 moveDirection;
    public float centAcc;
    public float tanVel;
    public static bool canKillEnemy;

    private int gravityState;

    // Use this for initialization
    void Start()
    {
        damage = 5;
        centAcc = 25f;
        tanVel = 5f;
        rb = GetComponent<Rigidbody2D>();
        pinkBulletCollider = GetComponent<Collider2D>();
        Destroy(gameObject, 10f);
        bulletSpeed = 600.0f;
        rb.AddForce((transform.position - GameObject.Find("player").transform.position).normalized * -bulletSpeed);
        canKillEnemy = false;
    }

    void Update()
    {
        if (Input.GetButton("X360_Y") && Player.fieldState == 1)
        {
            if (Vector2.Distance(transform.position, GameObject.Find("player").transform.position) < 3)
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



    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}
