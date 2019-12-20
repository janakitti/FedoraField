using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkStar : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D cd;
    private Vector2 randVect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, GameObject.Find("player").transform.position) < 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("player").transform.position, 0.03f);
        }
        else
        {
            randVect = new Vector2(UnityEngine.Random.Range(-5, 5), UnityEngine.Random.Range(-5, 5));
            rb.AddForce(randVect);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
