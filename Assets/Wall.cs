using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    public static Collider2D wallCollider;
    // Use this for initialization
    void Start () {
        wallCollider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
