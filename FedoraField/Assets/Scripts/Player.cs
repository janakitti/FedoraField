using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public static Collider2D playerCollider;

    public float speed;
    public static int fieldState;
    public int health;

    private bool facingRight;
    private bool facingLeft;
    private int moveLeft;
    private int moveRight;
    
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();

        health = 100;
        speed = 4.0f;
        fieldState = 0;
        rb.drag = 2.5f;
        rb.freezeRotation = true;
        facingRight = true;
        facingLeft = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        transform.position += Vector3.right * xAxis * speed * Time.deltaTime;
        transform.position += Vector3.up * yAxis * speed * Time.deltaTime;

        if (xAxis < 0)
        {
            facingLeft = true;
            facingRight = false;
        }
        if (xAxis > 0)
        {
            facingLeft = false;
            facingRight = true;
        }

        if (facingLeft && !facingRight)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            facingLeft = false;
        }
        else if (!facingLeft && facingRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            facingRight = false;
        }

        if (Input.GetButtonDown("X360_X"))
        {
            if (fieldState == 2)
            {
                fieldState = 0;
            } else
            {
                fieldState++;
            }
            Debug.Log("Field State: " + fieldState);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "NewProjectile")
        {
            collider.gameObject.tag = "SafeProjectile";
            Destroy(collider.gameObject);
            health -= 5;
        }
        if (collider.gameObject.tag == "Enemy")
        {
            rb.AddForce((transform.position - collider.transform.position)*500);
            health -= 1;
        }
    }
}
