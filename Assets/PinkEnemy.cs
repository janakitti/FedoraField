using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkEnemy : MonoBehaviour {
    public float speed;
    public Rigidbody2D rb;
    public GameObject pinkBullet;
    float fireRate;
    float nextFire;
    // Use this for initialization
    void Start () {
        fireRate = 3.0f;
        nextFire = Time.time;
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


        // Shooting
        CheckIfTimeToFire();

    }

    void CheckIfTimeToFire()
    {
        if(Time.time > nextFire)
        {
            Instantiate(pinkBullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

}
