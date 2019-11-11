using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBlockVer : MonoBehaviour
{

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Player.fieldState == 1)
        {
            if (Vector2.Distance(transform.position, GameObject.Find("player").transform.position) < 5)
            {
                rb.AddForce(Vector3.Project((transform.position - GameObject.Find("player").transform.position), Vector2.up) * -20.0f);
            }

        }
    }
}
