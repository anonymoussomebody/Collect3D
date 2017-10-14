using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventHandler : MonoBehaviour {

    // Quit the Game
    public void Exit()
    {
        Application.Quit();
    }

    // Load Scenes
    public void sceneMenu()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }
    public void sceneBarebones()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }
    public void sceneTutorial()
    {
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
    }
}
