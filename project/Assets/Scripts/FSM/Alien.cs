using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {

    private StateMachine stateMachine = new StateMachine();
    private Rigidbody2D rb;    
    private bool detectWall;

    [SerializeField]
    private bool analyzeComplete;

    [SerializeField]
    private bool Horizontal;

    [SerializeField]
    private float speed;

    [SerializeField]
    private bool test;

    private void Start()
    {
        detectWall = false;
        test = false;
        rb = GetComponent<Rigidbody2D>();
        stateMachine.ChangeState(new Walking(this.gameObject,rb, Horizontal, detectWall, speed));
    }

    private void FixedUpdate()
    {
        stateMachine.ExecuteStateUpdate();

        if (!detectWall)
        {
            test = true;

            stateMachine.ChangeState(new Walking(this.gameObject, rb,Horizontal,detectWall,speed));
        }
        if (detectWall)
        {
            speed = -speed;
            stateMachine.ChangeState(new Analyze(this.gameObject, analyzeComplete));
        }

    }

    // Change direction on collision
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider)
            detectWall = true;

        if (col.gameObject.tag == "Bullet")
        {
            gameObject.SetActive(false);
        }
    }





}
