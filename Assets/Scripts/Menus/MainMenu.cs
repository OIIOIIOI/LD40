using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    //declare button type
    public Text buttonStartText;
    public string myCurrentScene;

	// Use this for initialization
	void Start () {
	    if (myCurrentScene != "start")
        {
            buttonStartText.text = "Continue";
        }
	}
	
	public void LoadGame()
    {
        SceneManager.LoadScene(2); // Replace by current scene or next 
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("credits");
    }



}
