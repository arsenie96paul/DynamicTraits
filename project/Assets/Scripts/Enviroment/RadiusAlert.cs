using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusAlert : MonoBehaviour {

    [SerializeField]
    private GameEngine2 gameEngine;

    [SerializeField]
    private Alien_US _uSystem;

    private bool _active;
    private float[] _cTraits = new float[] { 0, 0, 0, 0 };

    private void Start()
    {
        _cTraits = _uSystem.GetTraits();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _cTraits[1] = _cTraits[1] + 1;
            _uSystem.SetTraits(_cTraits);
            _uSystem.SetChanges(true);
        }

        if (other.gameObject.tag == "Player" && _active)
        {
            gameEngine.GameWork(false);
            gameEngine.SetReason(1);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _cTraits[0] = _cTraits[0] + 1;
            _uSystem.SetTraits(_cTraits);
            _uSystem.SetChanges(true);
        }
    }

    public void SetACT(bool val)
    {
        _active = val;
    }
}
