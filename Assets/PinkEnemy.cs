using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkEnemy : MonoBehaviour {
    public float speed;
    public Rigidbody2D rb;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 targ = GameObject.Find("player").transform.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }
}
