using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Creates a new game.
    public void NewGame()
    {
        SceneManager.LoadScene("HUB");

    }
    //Loads a saved game.
    public void LoadGame()
    {

    }
    //Opens game's options.
    public void Options()
    {

    }
    //Quits game.
    public void QuitGame()
    {
        Application.Quit();
    }
}
