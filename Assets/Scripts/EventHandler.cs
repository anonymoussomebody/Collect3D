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
    public void sceneTutorial2()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }

    // Load Level Explore Scenes
    public void exploreBarebones()
    {
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
    }
    public void exploreTutorial()
    {
        SceneManager.LoadSceneAsync(3, LoadSceneMode.Single);
    }
}
