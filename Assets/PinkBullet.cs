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
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10f);
        bulletSpeed = 60.0f;
        rb.AddForce((transform.position - GameObject.Find("player").transform.position) * -bulletSpeed);
        /*
        
        
        moveDirection = (target.transform.position - transform.position).normalized * bulletSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        
        

        */
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce((transform.position - GameObject.Find("player").transform.position) * -10.0f);
        }
        else
        {
            rb.AddForce(Vector3.zero);
        }



        if (rb.IsTouching(PlayerScript.playerCollider))
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
}
