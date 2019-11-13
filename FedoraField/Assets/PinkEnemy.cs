using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkEnemy : MonoBehaviour
{
    public float speed;
    public float health;

    public Rigidbody2D rb;
    public Collider2D cd;
    public GameObject pinkBullet;
    public Collider2D pbCollider;


    float fireRate;
    float nextFire;

    float playerDist;

    private bool isSearching;

    // Use this for initialization
    void Start()
    {
        isSearching = true;
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();
        health = 10000;

        fireRate = 1f;
        nextFire = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        fireRate = Random.Range(2.0f, 4.0f);

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
        /*
        if (cd.IsTouching(pbCollider))
        {
            Debug.Log("s");
            health -= 25;
        }
        */





    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, GameObject.Find("player").transform.position) < 7 && Vector2.Distance(transform.position, GameObject.Find("player").transform.position) > 3)
        {
            isSearching = false;
            transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("player").transform.position, 0.03f);
        }
        else
        {
            isSearching = true;
        }


    }


    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            if (isSearching == true)
            {
                Vector2 movement = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
                rb.AddForce(movement);
            }
            Instantiate(pinkBullet, transform.TransformPoint(1.0f, 0, 0), Quaternion.identity);
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
            health -= 25;
        }
    }


}
