using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien_Move : MonoBehaviour
{ 
    private Rigidbody2D rb;

    // Public variable
    [SerializeField]
    private bool Horizontal;

    [SerializeField]
    private float value;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();         // get component from rigidbody in Unity
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Movement();
    }

    // Change direction on collision
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider)
            value = -value;

        if (col.gameObject.tag == "Bullet")
        {
            gameObject.SetActive(false);
        }
    } 
    // Movement Function
    private void Movement()
    {
        // Movement 
        Vector3 movement;

        if (Horizontal)
        {
            movement = new Vector3(value, 0.0f, 0.0f);
        }
        else
        {
            movement = new Vector3(0.0f, value, 0.0f);
        }

        rb.velocity = movement;
    }
}
