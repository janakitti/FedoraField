using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkBullet : MonoBehaviour
{
    float bulletSpeed;
    public float pinkBulletAcceleration;
    Rigidbody2D rb;
    public GameObject target;
    Vector2 moveDirection;
    public static Collider2D pinkBulletCollider;

    public float centAcc;
    public float tanVel;

    private bool canKillEnemy;

    // Use this for initialization
    void Start()
    {
        centAcc = 25f;
        tanVel = 5f;
        rb = GetComponent<Rigidbody2D>();
        pinkBulletCollider = GetComponent<Collider2D>();
        Destroy(gameObject, 10f);
        bulletSpeed = 120.0f;
        rb.AddForce((transform.position - GameObject.Find("player").transform.position) * -bulletSpeed);

        canKillEnemy = false;

        /*
        
        
        
        moveDirection = (target.transform.position - transform.position).normalized * bulletSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        
        

        */
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            if (Vector2.Distance(transform.position, GameObject.Find("player").transform.position) < 3)
            {
                rb.AddForce((transform.position - GameObject.Find("player").transform.position) * -centAcc);
                rb.velocity = Vector2.Perpendicular(transform.position - GameObject.Find("player").transform.position) * tanVel;
            }
           
        }
        else
        {
            rb.AddForce(Vector3.zero);
        }



        if (rb.IsTouching(PlayerScript.playerCollider) || rb.IsTouching(Wall.wallCollider))
        {
            // CAMERA SHAKE
            //CameraFollow.target.position += Vector3.right * 1;
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        

    }

    void BulletOrbit()
    {

    }
}
