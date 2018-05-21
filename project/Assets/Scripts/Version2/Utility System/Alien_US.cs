using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien_US : MonoBehaviour {

    [SerializeField]
    private float _maxNumber;   // Max value of a trait

    [SerializeField]
    private ManageUS _manager;

    // Private variables
    private bool _change;       // Return if traits were changed or not
    private int _indexNum;      // Number of traits
    private int _behaviour;     // Stock behaviour number
    private string _trait;
    private float[] _traits = new float[] { 0,0,0,0}; // stock the traits values (before probability)
    private List<KeyValuePair<string, float>> _traitsList = new List<KeyValuePair<string, float>>(); // Stock trait and probability

    // Personality traits: can be changed or fixed, affecting NPCs
    private float _brave;       // can be changed
    private float _active;      // can be changed
    private float _precise;     // FIXED

    // Probability traits
    private float _pBrave;
    private float _pActive;
    private float _pPrecise;

    // Initialize
    private void Start () {
        Initialize();
    }
	
	// Update is called once per frame
	private void Update ()
    {
        if (!_change)
        {
            return;
        }
        ChangeTrait();        
    }

    private void Initialize()
    {
        _brave = Random.Range(0, _maxNumber);
        _active = Random.Range(0, _maxNumber);
        _precise = Random.Range(0, _maxNumber);

        _traits[0] = _brave;
        _traits[1] = _active;
        _traits[2] = _precise;

        _indexNum = 3;
        _change = false;

        CheckProbability();
        OrderProbability();
        SetTrait();
        _manager.Initialize();
    }

    private void ChangeTrait()
    {
        CheckProbability();
        OrderProbability();
        SetTrait();
    }

    // This method assign the probability for each personality trait and it add them into the list
    private void CheckProbability()
    {
        float total = _traits[0] + _traits[1] + _traits[2];
        // Probability of each number
        _pBrave = _traits[0] / total;
        _pActive = _traits[1] / total;
        _pPrecise = _traits[2] / total;

        _traitsList.Insert(0, new KeyValuePair<string, float>("Brave", _pBrave));
        _traitsList.Insert(1, new KeyValuePair<string, float>("Active", _pActive));
        _traitsList.Insert(2, new KeyValuePair<string, float>("Precise", _pPrecise));
    }

    // This method used bubble sort to order the array of the probabilities
    private void OrderProbability()
    {
        bool swap = true;

        while (swap)
        {
            swap = false;
            for (int i = 0; i < _traitsList.Count; i++)
                for (int j = i + 1; j < _traitsList.Count; j++)
                {
                    if (_traitsList[i].Value > _traitsList[j].Value)
                    {
                        var aux = _traitsList[i];
                        _traitsList[i] = _traitsList[j];
                        _traitsList[j] = aux;
                        swap = true;
                    }
                }
        }
    }

    // This method return the index of the picked trait ( It pick a random element based on probability)
    // using the cumulative probability 
    private int PickTrait()
    {
        float Max = 0;
        int found = 0;

        for (int i = 0; i < _traitsList.Count; i++)
        {
            Max += _traitsList[i].Value;
        }

        float pick = Random.Range(0, Max);
        float cumulative = 0.0f;

        for (int i = 0; i < _traitsList.Count; i ++)
        {
            cumulative += _traitsList[i].Value;

            if (pick <= cumulative)
            {
                found = i;
                break;
            }
        }
        return found;
    }

    private void SetTrait()
    {
        _trait = _traitsList[PickTrait()].Key;


        if (_traitsList[PickTrait()].Value > _maxNumber / 2)
        {
            _behaviour = 1;
        }
        else
        {
            _behaviour = 2;
        }
    }
    
    // -- Public methods to set and get and change values --- 

    // -- changes 
    public void SetChanges(bool value)
    {
        _change = value;
    }

    public bool GetChanged()
    {
        return _change;
    }

    // -- traits

    public void SetTraits( float[] newTraits)
    {
        _traits = newTraits;
    }

    public float[] GetTraits()
    {
        return _traits;
    }

    // -- traits pair list

    public List<KeyValuePair<string, float>> GetTaitsList()
    {
        return _traitsList;
    }

    // -- behaviour & trait

    public int GetBehaviour()
    {
        return _behaviour;
    }

    public string GetTrait( )
    {
        return _trait;
    }
}