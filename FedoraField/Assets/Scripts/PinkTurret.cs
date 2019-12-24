using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkTurret : MonoBehaviour
{
    public Rigidbody2D rb;
    public static Collider2D cd;
    public GameObject pinkBullet;
    public Collider2D pbCollider;

    float fireRate;
    float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();

        fireRate = 1f;
        nextFire = Time.time; // Holds gametime in seconds since start of play
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(pinkBullet, transform.TransformPoint(0f, 0.5f, 0), Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
