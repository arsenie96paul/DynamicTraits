using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine2 : MonoBehaviour
{
    // Serialized values

    [SerializeField]
    private GameObject vCone;

    [SerializeField]
    private GameObject sRadius;

    [SerializeField]
    private GameObject ESC;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject controlPanel;

    [SerializeField]    
    private GameObject gameOver;

    // Private Value
    private GameObject[] soundRadius;
    private GameObject[] visualCone;
    private GameObject[] details;

    private float radiusVal;
    private float coneVal;
    private bool Switc = false;

    private bool gameWork;
    private int reason;       // 0 - Dead / 1 - Seen // 2 - Pause
    private int detailsS;


    // Use this for initialization
    void Start()
    {

        // initialize Game Objects 
        soundRadius = GameObject.FindGameObjectsWithTag("Sound_Radius");
        visualCone = GameObject.FindGameObjectsWithTag("Visual_Cone");
        details = GameObject.FindGameObjectsWithTag("Details");

        // Initialize Values
        detailsS = -9;
        radiusVal = -9;
        coneVal = -9;
        gameWork = true;
    }

    // Update is called once per frame
    void Update()
    {

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
            gameOver.SetActive(true);
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
        if (Input.GetKeyDown(KeyCode.Escape) && Switc == false)
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

        if (Input.GetKeyDown("3"))
        {
            for (int i = 0; i < details.Length; i++)
                details[i].transform.position = new Vector3(details[i].transform.position.x, details[i].transform.position.y, detailsS);

            detailsS = -detailsS;
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

