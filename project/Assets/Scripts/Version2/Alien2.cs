using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien2 : MonoBehaviour
{
    [SerializeField]
    private Alien_US _uSystem;

    [SerializeField]
    private bool Horizontal;

    [SerializeField]
    private float value;

    // Private variables
    private float _health;
    private Rigidbody2D rb;
    private Vector3 movement;
    private float[] _cTraits = new float[] { 0, 0, 0, 0 }; 

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();         // get component from rigidbody in Unity
        _health = 3;

        _cTraits = _uSystem.GetTraits();
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
        CheckLife();
    }

    // Change direction on collision
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider)
            value = -value;

        if (col.gameObject.tag == "Bullet")
        {
            _health--;
            _cTraits[1] = _cTraits[1] - 1;
            _uSystem.SetTraits(_cTraits);
            _uSystem.SetChanges(true);
        }
    }
    // Movement Function
    private void Movement()
    {

        if (Horizontal)
        {
            movement = new Vector3(value, 0.0f, 0.0f);
        }
        else
        {
            movement = new Vector3(0.0f, value, 0.0f);
        }

        rb.velocity = movement * 2;
    }

    private void CheckLife()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Public methods

    public void DoubleHealth()
    {
        _health = _health * 2;
    }
    
    public float GetSpeed()
    {
        return value;
    }

    public void SetSpeed( int number)
    {
        value = value + number;
    }

    public void ResetSpeed()
    {
        value = 1.0f;
    }

}
