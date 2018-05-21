using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{

    // private
    private Rigidbody2D rb;
    private bool isGun = false;
    private float nextFire;

    // public
    public GameObject weapon;
    public GameObject bullet;

    public GameEngine2 gameEngine;
    public Transform spawnShot;
    public float fireRate;

    public float speed;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Fire();
        Move();
        LookAt();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Pick Up Weapone
        if (col.gameObject.tag == "Gun")
        {
            weapon.SetActive(true);
            isGun = true;
        }

        // Game over
        if (col.gameObject.tag == "Alien")
        {
            gameEngine.GameWork(false);
            gameEngine.SetReason(0);
        }
    }

    // Movement
    void Move()
    {
        // no imput needed
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        rb.velocity = movement * speed;
    }

    // Look at mouse 
    void LookAt()
    {
        var mousePos = Input.mousePosition;
        var screenPos = Camera.main.WorldToScreenPoint(transform.localPosition);
        var offset = new Vector2(mousePos.x - screenPos.x, mousePos.y - screenPos.y);
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    // Shoot bullet
    void Fire()
    {
        if (Input.GetMouseButtonDown(0) && isGun && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, spawnShot.position, spawnShot.rotation);
        }
    }
}
