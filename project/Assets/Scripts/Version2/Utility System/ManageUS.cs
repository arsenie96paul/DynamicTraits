using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageUS : MonoBehaviour {

    [SerializeField]
    private Alien_US _utilitySystem;

    [SerializeField]
    private Alien2 _alien;

    [SerializeField]
    private ConeEnd _first;

    [SerializeField]
    private ConeEnd _second;

    [SerializeField]
    private RadiusAlert _radius;

    [SerializeField]
    private GameObject _spy;

    [SerializeField]
    private TextMesh _traitText;

    [SerializeField]
    private TextMesh _behaviourText ;

    private int _behaviour;
    private string _trait;

    // Use this for initialization
    public void Initialize  () {
        _behaviour = _utilitySystem.GetBehaviour();
        _trait = _utilitySystem.GetTrait();

        _traitText.text = _trait;
        _behaviourText.text = _behaviour.ToString();

        if (_trait == "Brave")
        {
            Normal();
            Brave();
        }
        if (_trait == "Active")
        {
            Normal();
            Active();
        }
        if (_trait == "Precise")
        {
            Normal();
            Precise();
        }
    }
	
	// Update is called once per frame
	private void Update () {

        if (!_alien.gameObject.activeSelf)
        {
            Normal();
        }

        if (_utilitySystem.GetChanged())
        {
            _behaviour = _utilitySystem.GetBehaviour();
            _trait = _utilitySystem.GetTrait();

            _traitText.text = _trait;
            _behaviourText.text = _behaviour.ToString();

            Debug.Log(_trait);

            if (_trait == "Brave")
            {
                Normal();
                Brave();
            }
            if (_trait == "Active")
            {
                Normal();
                Active();
            }
            if (_trait == "Precise")
            {
                Normal();
                Precise();
            }


            _utilitySystem.SetChanges(false);
        }
		
	}

    private void Active()
    {
        if (_behaviour == 1)
        {
            _alien.SetSpeed(2);
        }
        else
        {
            _alien.SetSpeed(3);
        }
    }

    private void Brave()
    {
        if (_behaviour == 1)
        {
            _alien.DoubleHealth();
        }
        else
        {
            _spy.SetActive(true);
        }
    }

    private void Precise()
    {
        if (_behaviour == 1)
        {
            _first.SetACT(true);
            _second.SetACT(true);
        }
        else
        {
            _radius.SetACT(true);
        }
    }
    
    private void Normal()
    {
        _spy.SetActive(false);
        _alien.ResetSpeed();

        _first.SetACT(false);
        _second.SetACT(false);

        _radius.SetACT(false);
    }
}
