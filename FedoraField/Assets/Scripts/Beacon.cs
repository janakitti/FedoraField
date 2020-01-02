using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D cd;
    public static int orbsCollected;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();
        orbsCollected = 0;

        rb.angularVelocity = 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Orb")
        {
            collider.gameObject.tag = "BlankTag";
            Destroy(collider.gameObject);
            orbsCollected++;
        }
    }
}
