using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkEnemy : Enemy
{
    public Rigidbody2D rb;
    public static Collider2D cd;
    public GameObject pinkBullet;
    public Collider2D pbCollider;

    public float speed;
    public float health;



    float fireRate;
    float nextFire; 
    float playerDist;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();

        health = 25;
        damage = 1;
        nextFire = Time.time; // Holds gametime in seconds since start of play
    }

    // Update is called once per frame
    void Update()
    {
        fireRate = Random.Range(2.0f, 4.0f); // Randomize when the next shot should be

        Vector3 targ = GameObject.Find("player").transform.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Shooting
        CheckIfTimeToFire();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, GameObject.Find("player").transform.position) < 7 && Vector2.Distance(transform.position, GameObject.Find("player").transform.position) > 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("player").transform.position, 0.03f);
        }
        else
        {
        }
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(pinkBullet, transform.TransformPoint(0f, 0, 0), Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    void LateUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Projectile")
        {
            collider.gameObject.tag = "SafeProjectile";
            Destroy(collider.gameObject);
            health -= collider.gameObject.GetComponent<PinkProjectile>().damage;
            
        } else if (collider.gameObject.tag == "MetalBlock")
        {
            collider.gameObject.tag = "SafeMetalBlock";
            health -= collider.gameObject.GetComponent<MetalBlock>().damage;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "SafeMetalBlock")
        {
            collider.gameObject.tag = "MetalBlock";
        }
    }
}
