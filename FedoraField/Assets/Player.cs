using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb;
    public static Collider2D playerCollider;

    public static int fieldState;

    private bool facingRight;
    private bool facingLeft;

    private int moveLeft;
    private int moveRight;
    
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 2.5f;
        rb.freezeRotation = true;

        playerCollider = GetComponent<Collider2D>();

        facingRight = true;
        facingLeft = false;
        speed = 4.0f;

        fieldState = 0;
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
            if (fieldState == 1)
            {
                fieldState = 0;
            } else
            {
                fieldState++;
            }
            Debug.Log("Field State: " + fieldState);
        }

















        /*

        if (Input.GetKey(KeyCode.Alpha0))
        {
            fieldState = 0;
        } else if (Input.GetKey(KeyCode.Alpha1))
        {
            fieldState = 1;
        }

        //int moveLeft = Input.GetKey(KeyCode.A) ? 1 : 0;
        if (Input.GetKey(KeyCode.A))
        {
            moveLeft = 1;
            facingLeft = true;
            facingRight = false;
        } else
        {
            moveLeft = 0;
        }
        //int moveRight = Input.GetKey(KeyCode.D) ? 1 : 0;
        if (Input.GetKey(KeyCode.D))
        {
            moveRight = 1;
            facingLeft = false;
            facingRight = true;
        }
        else
        {
            moveRight = 0;
        }
        int moveUp = Input.GetKey(KeyCode.W) ? 1 : 0;
        int moveDown = Input.GetKey(KeyCode.S) ? 1 : 0;
        float speedMultiplier = 1;

        // Diagonal movement speed adjuster
        if (moveLeft + moveRight > 0 && moveUp + moveDown > 0)
        {
            speedMultiplier = Mathf.Sqrt(2) / 2;
        }
        else
        {
            speedMultiplier = 1;
        }
        transform.position += Vector3.right * (moveRight - moveLeft) * speedMultiplier * speed * Time.deltaTime;
        transform.position += Vector3.up * (moveUp - moveDown) * speedMultiplier * speed * Time.deltaTime;


        if (facingLeft && !facingRight)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            facingLeft = false;
        } else if (!facingLeft && facingRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            facingRight = false;
        }



        */


    }

    private void Flip(int scale) // Flip the player facing direction
    {
        if (facingRight == true && scale == -1)
        {
            Debug.Log("hi");
            Vector3 horScale = transform.localScale;
            horScale.x *= -1;
            transform.localScale = horScale;
            facingRight = false;
        }
        else if (facingRight == false && scale == 1)
        {
            Vector3 horScale = transform.localScale;
            horScale.x *= -1;
            transform.localScale = horScale;
            facingRight = true;
        }

    }
}
