using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerLS : MonoBehaviour
{
    public Rigidbody2D rb;
    public static Collider2D playerCollider;

    public float speed;

    private bool facingRight;
    private bool facingLeft;
    private int moveLeft;
    private int moveRight;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();

        speed = 4.0f;
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
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

    }
}
