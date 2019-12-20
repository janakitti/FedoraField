using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDest : MonoBehaviour
{
    public static Collider2D cd;
    public static Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        cd = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "WallDestroyer")
        {
            Destroy(rb);
        }
    }
}
