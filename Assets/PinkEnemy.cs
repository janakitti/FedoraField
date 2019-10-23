using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkEnemy : MonoBehaviour {
    public float speed;
    public Rigidbody2D rb;
    public GameObject pinkBullet;
    float fireRate;
    float nextFire;
    float fireRateInterval;
    float nextInterval;
    float playerDist;

    private bool isSearching;
    // Use this for initialization
    void Start () {
        isSearching = true;
        rb = GetComponent<Rigidbody2D>();
        fireRate = 5f;
        nextFire = Time.time;
        fireRateInterval = 5.0f;
        nextInterval = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        
        Vector3 targ = GameObject.Find("player").transform.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        

        // Shooting

        CheckIfTimeToFire();
        
        if (rb.IsTouching(PinkBullet.pinkBulletCollider))
        {
            Destroy(gameObject);
        }

        
        
        
        

    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, GameObject.Find("player").transform.position) < 7 && Vector2.Distance(transform.position, GameObject.Find("player").transform.position) > 3)
        {
            isSearching = false;
            transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("player").transform.position, 0.03f);
        } else
        {
            isSearching = true;
        }
    }
       

    void CheckIfTimeToFire()
    {
        if(Time.time > nextFire)
        {
            if (isSearching == true)
            {
                Vector2 movement = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
                rb.AddForce(movement);
            }
            Instantiate(pinkBullet, transform.TransformPoint(1.5f, 0, 0), Quaternion.identity);
            nextFire = Time.time + fireRate;
        }

    }

 

}
