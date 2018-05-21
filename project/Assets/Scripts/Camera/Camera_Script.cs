using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour {

    GameObject player;

    private Rigidbody2D rb;

    private bool pCam;
    private float bossPos = 14.25f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        pCam = true;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        Vector3 movement;

        if (pCam)
        {
            this.transform.position = new Vector3(this.transform.position.x, player.transform.position.y, this.transform.position.z);
        }
        else
        {

            if ( transform.position.y < bossPos)
            {
                movement = new Vector3(0.0f, 3.0f, 0.0f);
            }
            else
            {
                movement = new Vector3(0.0f, 0.0f, 0.0f);
            }
            rb.velocity = movement;


        }


    }
    public void SetCam(bool cam)
    {
        pCam = cam;
    }
}
