using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    [SerializeField]
    private GameEngine2 gameEngine2;

    [SerializeField]
    private GameEngine gameEngine;

    [SerializeField]
    private GameObject menu;

    public void LoadScene(int level)
    {
        //Application.LoadLevel(level); <--- OUT OF DATE
        SceneManager.LoadScene(level);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        gameEngine.GameWork(true);
        menu.SetActive(false);
    }

    public void Resume2()
    {
        gameEngine2.GameWork(true);
        menu.SetActive(false);

    }
}
