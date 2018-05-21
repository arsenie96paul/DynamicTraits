using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour {

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private GameObject _controlPanel;

    [SerializeField]
    private GameObject _endGame;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject == _player)
        {
            _player.SetActive(false);
            _controlPanel.SetActive(false);
            _endGame.SetActive(true);
        }
    }
}
