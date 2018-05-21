using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : IState
{
    private GameObject alien;
    private Rigidbody2D rb;
    private bool detectwall;
    private bool Horizontal;
    private float value;

    public Walking(GameObject alien, Rigidbody2D alienB, bool horiz, bool isWall, float speed)
    {
        this.alien = alien;
        this.rb = alienB;
        this.detectwall = isWall;
        this.Horizontal = horiz;
        this.value = speed;
    }

    public void Enter()
    {
      
    }

    public void Execute()
    {
        Movement();

    }

    public void Exit()
    {
       
    }

    void Movement()
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


        if (detectwall)
        {
            alien.transform.position = new Vector3(alien.transform.position.x, alien.transform.position.y - 0.1f, alien.transform.position.z);
            detectwall = false;
        }

         rb.velocity = movement;
    }
}
