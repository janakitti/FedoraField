using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconScript : MonoBehaviour {
    public static Collider2D beaconCollider;
    public static int orbCount;

	// Use this for initialization
	void Start () {
        beaconCollider = GetComponent<Collider2D>();
        orbCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
