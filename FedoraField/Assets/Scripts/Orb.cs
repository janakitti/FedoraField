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
        orbAcceleration = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.isUsingField == 0 && Vector2.Distance(transform.position, GameObject.Find("player").transform.position) < 8)
        {
            rb.AddForce((transform.position - GameObject.Find("player").transform.position) * -orbAcceleration);
        }
        else
        {
            rb.AddForce(Vector3.zero);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

    }


}
