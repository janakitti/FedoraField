using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerScript : MonoBehaviour {
    public float speed;
    public Rigidbody2D rb;
    private bool facingRight;
    public static Collider2D playerCollider;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 2.5f;
        rb.freezeRotation = true;

        playerCollider = GetComponent<Collider2D>();

        facingRight = true;
        speed = 7.0f;
    }
	
	// Update is called once per frame
	void Update () {


        // Using force vectors (allows for inertia)
        /*
        rb.AddForce(transform.right * (moveRight - moveLeft) * speedMultiplier * speed);
        rb.AddForce(transform.up * (moveUp - moveDown) * speedMultiplier * speed);
        */


        // Using a more kinematic approach, no inertia





        // OrbScript.orbSpeed = Input.GetKey(KeyCode.Space) ? 2.0f : 0.0f;
    }


    private void FixedUpdate()
    {

        int moveLeft = Input.GetKey(KeyCode.A) ? 1 : 0;
        int moveRight = Input.GetKey(KeyCode.D) ? 1 : 0;
        int moveUp = Input.GetKey(KeyCode.W) ? 1 : 0;
        int moveDown = Input.GetKey(KeyCode.S) ? 1 : 0;

        float speedMultiplier = 1;


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
        



    }

    private void Flip(int scale)
    {
        
        if (facingRight == true && scale == -1)
        {
            Debug.Log("hi");
            Vector3 horScale = transform.localScale;
            horScale.x *= -1;
            transform.localScale = horScale;
            facingRight = false;
        } else if (facingRight == false && scale == 1)
        {
            Vector3 horScale = transform.localScale;
            horScale.x *= -1;
            transform.localScale = horScale;
            facingRight = true;
        }

    }
}
