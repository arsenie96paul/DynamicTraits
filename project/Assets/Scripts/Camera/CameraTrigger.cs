using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {

    public Camera_Script cam;

    void OnTriggerEnter2D(Collider2D col)
    {
        if ( col.gameObject.tag == "Player")
        {
            cam.SetCam(false); // take camera down from the player
            this.gameObject.SetActive(false); // dezactivate trigger
        }
    }


}
