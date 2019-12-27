using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public static Collider2D playerCollider;

    public float speed;
    public static int fieldState;
    public static int isUsingField;
    public int health;
    public DeathMenu deathMenu;
    public FailureMenu failureMenu;
    public CompletionMenu completionMenu;

    private bool facingRight;
    private bool facingLeft;
    private int moveLeft;
    private int moveRight;
    
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();

        health = 100;
        speed = 4.0f;
        fieldState = 0;
        isUsingField = -1;
        rb.drag = 2.5f;
        rb.freezeRotation = true;
        facingRight = true;
        facingLeft = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        transform.position += Vector3.right * xAxis * speed * Time.deltaTime;
        transform.position += Vector3.up * yAxis * speed * Time.deltaTime;

        if (xAxis < 0)
        {
            facingLeft = true;
            facingRight = false;
        }
        if (xAxis > 0)
        {
            facingLeft = false;
            facingRight = true;
        }

        if (facingLeft && !facingRight)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            facingLeft = false;
        }
        else if (!facingLeft && facingRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            facingRight = false;
        }

        if (Input.GetButtonDown("X360_X"))
        {
            if (fieldState == 2)
            {
                fieldState = 0;
            } else
            {
                fieldState++;
            }
        }

        if (Input.GetButton("X360_Y"))
        {
            if (Player.fieldState == 0)
            {
                isUsingField = 0;
            } else if (Player.fieldState == 1)
            {
                isUsingField = 1;
            } else if (Player.fieldState == 2)
            {
                isUsingField = 2;
            }
        } else
        {
            isUsingField = -1;
        }





        if (health <= 0) // Death trigger
        {
            OnDeath();
            health = 0;
        }

        if (Beacon.orbsCollected + OrbCount.levelOrbs.Length < LevelManager.orbsRequired)
        {
            OnFailure();
        }

        if (Beacon.orbsCollected == LevelManager.orbsRequired)
        {
            OnCompletion();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Projectile" || collider.gameObject.tag == "NewProjectile")
        {
            collider.gameObject.tag = "SafeProjectile";
            Destroy(collider.gameObject);
            health -= collider.gameObject.GetComponent<PinkProjectile>().damage;
        }
        if (collider.gameObject.tag == "Enemy")
        {
            Debug.Log("Ouf");
            rb.AddForce((transform.position - collider.transform.position)*500);
            health -= collider.gameObject.GetComponent<Enemy>().damage;
        }
    }

    void OnDeath()
    {
        deathMenu.ToggleEndMenu();
    }

    void OnFailure()
    {
        failureMenu.ToggleEndMenu(Beacon.orbsCollected, LevelManager.orbsRequired);
    }

    void OnCompletion()
    {
        completionMenu.ToggleEndMenu(0);
    }
}
