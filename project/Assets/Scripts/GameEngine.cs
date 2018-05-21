using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour {

    public GameObject vCone;
    public GameObject sRadius;
    public GameObject ESC;
    public GameObject player;
    public GameObject controlPanel;
    public GameObject gameOver;
    public GameObject Spy;


    // Private Value
    private GameObject[] soundRadius;
    private GameObject[] visualCone;


    private float radiusVal;
    private float coneVal;
    private bool Switc = false;

    private bool gameWork;
    private int reason;       // 0 - Dead / 1 - Seen // 2 - Pause


    // Use this for initialization
    void Start () {

        // initialize Game Objects 
        soundRadius = GameObject.FindGameObjectsWithTag("Sound_Radius");
        visualCone = GameObject.FindGameObjectsWithTag("Visual_Cone");

        // Initialize Values
        radiusVal = -9;
        coneVal = -9;
        gameWork = true;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        Display();
        Menu();
        RunState();
    }

    public void GameWork(bool gameWork)
    {
        this.gameWork = gameWork;
    }

    public void SetReason(int reason)
    {
        this.reason = reason;
    }

    void RunState()
    {
        if (gameWork == false && reason == 0)
        {
            controlPanel.SetActive(false);
            gameOver.SetActive(true);

        }
        if (gameWork == false && reason == 1)
        {
            controlPanel.SetActive(false);
            Spy.SetActive(true);
        }
        if (gameWork == false && reason == 2)
        {
            controlPanel.SetActive(false);
        }

        if (gameWork == true)
        {
            controlPanel.SetActive(true);
        }
    }

    void Menu()
    {
   

        if ( Input.GetKeyDown(KeyCode.Escape) && Switc == false)
        {
            ESC.SetActive(true);
            Switc = true;
            gameWork = false;
            reason = 2;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && Switc)
        {
            ESC.SetActive(false);
            Switc = false;
            gameWork = true;
        }

    }

    // Key for Sound Radius and Visual Cone
    void Display()
    {
        // 1 for Sound Radius
        if (Input.GetKeyDown("1"))
        {
            for (int i = 0; i < soundRadius.Length; i++)
                soundRadius[i].transform.position = new Vector3(soundRadius[i].transform.position.x, soundRadius[i].transform.position.y, radiusVal);

            radiusVal = -radiusVal;
        }

        // For text
        if (radiusVal < 0)
        {
            sRadius.SetActive(false);
        }
        else
        {
            sRadius.SetActive(true);
        }

        // 2 for Visual Cone
        if (Input.GetKeyDown("2"))
        {
            for (int i = 0; i < visualCone.Length; i++)
                visualCone[i].transform.position = new Vector3(visualCone[i].transform.position.x, visualCone[i].transform.position.y, coneVal);

            coneVal = -coneVal;
        }

        // For text
        if (coneVal < 0)
        {
            vCone.SetActive(false);
        }
        else
        {
            vCone.SetActive(true);
        }

    }
}

