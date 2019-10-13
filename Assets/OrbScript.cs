using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour {
    public float speed = 1.0f;
    public static float orbSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Move our position a step closer to the target.
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("player").transform.position, (float)(orbSpeed * Time.deltaTime + 9.81 * Mathf.Pow(Time.deltaTime, 2)));

        ;

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, GameObject.Find("player").transform.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            GameObject.Find("player").transform.position *= -1.0f;
        }
    }
}
