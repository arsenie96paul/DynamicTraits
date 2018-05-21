using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : MonoBehaviour {

    [SerializeField]
    private GameEngine gameEngine;

    void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.gameObject.tag == "Player")
        {
            gameEngine.GameWork(false);
            gameEngine.SetReason(1);    
        }
    }

}
