using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    //private
    private Rigidbody2D rb;
    
    [SerializeField]
    private Vector3 speed;

    [SerializeField]
    private float floatSpeed;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * 10;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject);
    }
}
