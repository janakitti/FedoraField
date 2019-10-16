using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour {

    public Rigidbody2D orbRB;
    public Collider2D orbCollider;

    public float orbAcceleration;
    public int orbAttract = 0;
    public float speed;
    public static float orbSpeed;
    public static float acceleration = 9.81f;
    public static float orbStep;
    private int accOrb;
	// Use this for initialization
	void Start () {
        orbRB = GetComponent<Rigidbody2D>();
        orbRB.drag = 1f;

        orbCollider = GetComponent<Collider2D>();

        orbRB.freezeRotation = true;
        orbAcceleration = 0.05f;

	}
	
	// Update is called once per frame
	void Update () {
        // Move our position a step closer to the target.
        /*
        accOrb = orbSpeed > 0 ? 1 : 0;

        orbStep = (float)(orbSpeed * Time.deltaTime + accOrb * (acceleration * Mathf.Pow(Time.deltaTime, 2)));
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("player").transform.position, orbStep);
        */

        if (Input.GetKey(KeyCode.Space))
        {
            orbRB.AddForce((transform.position - GameObject.Find("player").transform.position) * -orbAcceleration);
        } else
        {
            orbRB.AddForce(Vector3.zero);
        }

        /*

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, GameObject.Find("player").transform.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            GameObject.Find("player").transform.position *= -1.0f;
        }

        */



        // Colliding with Beacon

        if (orbCollider.IsTouching(BeaconScript.beaconCollider))
        {
            BeaconScript.orbCount += 1;
            Destroy(gameObject);
        }


    }


}
