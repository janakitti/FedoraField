using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkStar : Enemy
{
    public Rigidbody2D rb;
    public Collider2D cd;

    public float attackSpeed;
    public float attackForce;
    public float sensoryRange;

    private Vector2 randVect;
    private bool isAttacking;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();

        attackSpeed = 0.07f;
        attackForce = 80f;
        sensoryRange = 8f;
        damage = 10;
        health = 30;
        isAttacking = false;
    }

    private void FixedUpdate()
    {
        if (isAttacking == false && Vector2.Distance(transform.position, GameObject.Find("player").transform.position) < sensoryRange)
        {
            rb.angularVelocity = 1000;
            rb.AddForce((transform.position - GameObject.Find("player").transform.position) * -attackForce);
            isAttacking = true;
        }

        if (isAttacking == true && Vector2.Distance(transform.position, GameObject.Find("player").transform.position) < sensoryRange)
        {
            //transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("player").transform.position, attackSpeed);
        }
        else if (isAttacking == true && Vector2.Distance(transform.position, GameObject.Find("player").transform.position) >= sensoryRange)
        {
            isAttacking = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Projectile")
        {
            Debug.Log("HIT");
            collider.gameObject.tag = "SafeProjectile";
            Destroy(collider.gameObject);
            health -= collider.gameObject.GetComponent<PinkProjectile>().damage;

        }
        else if (collider.gameObject.tag == "MetalBlock")
        {
            collider.gameObject.tag = "SafeMetalBlock";
            health -= collider.gameObject.GetComponent<MetalBlock>().damage;
        }
    }
}
