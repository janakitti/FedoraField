using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBlock : MonoBehaviour
{

    Rigidbody2D rb;

    public int damage;

    public Vector3 xVector;
    public Vector3 yVector;
    public Vector3 axisVector;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        damage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("X360_Y") && Player.fieldState == 2 && Vector2.Distance(transform.position, GameObject.Find("player").transform.position) < 5)
        {
            xVector = Vector3.Project((transform.position - GameObject.Find("player").transform.position), Vector2.right);
            yVector = Vector3.Project((transform.position - GameObject.Find("player").transform.position), Vector2.up);
            axisVector = xVector.magnitude > yVector.magnitude ? xVector : yVector;
            rb.AddForce(axisVector * -10.0f);

        }
    }
}
