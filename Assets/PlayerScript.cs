using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerScript : MonoBehaviour {
    public float speed = 5.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int moveLeft = Input.GetKey(KeyCode.A) ? 1 : 0;
        int moveRight = Input.GetKey(KeyCode.D) ? 1 : 0;
        int moveUp = Input.GetKey(KeyCode.W) ? 1 : 0;
        int moveDown = Input.GetKey(KeyCode.S) ? 1 : 0;
        OrbScript.orbSpeed = Input.GetKey(KeyCode.Space) ? 2.0f : 0.0f;
        float speedMultiplier = 1; 
        if (moveLeft + moveRight > 0 && moveUp + moveDown > 0)
        {
            speedMultiplier = Mathf.Sqrt(2) / 2;
        } else
        {
            speedMultiplier = 1;
        }
        transform.position += Vector3.right * (moveRight - moveLeft) * speedMultiplier * speed * Time.deltaTime;
        transform.position += Vector3.up * (moveUp - moveDown) * speedMultiplier * speed * Time.deltaTime;
    }
}
