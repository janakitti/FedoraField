using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D cd;
    public float orbAcceleration;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();
        orbAcceleration = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("X360_Y") && Player.fieldState == 2)
        {
            rb.AddForce((transform.position - GameObject.Find("player").transform.position) * -orbAcceleration);
        }
        else
        {
            rb.AddForce(Vector3.zero);
        }
    }
}
