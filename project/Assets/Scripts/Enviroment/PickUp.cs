using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider)
        {
            this.gameObject.SetActive(false);
        }
    }
}
