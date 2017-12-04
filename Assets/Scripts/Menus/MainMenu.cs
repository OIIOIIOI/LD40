using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    //declare button type
    public Sprite ImgContinue;
    public Sprite ImgContinueSelect;
    public string myCurrentScene;
    public Button buttonStart;
    public Button buttonContinue;

   // SpriteState spriteState1 = new SpriteState();

    // Use this for initialization
    void Start () {
        if (myCurrentScene != "start")
        {
            buttonStart.image.sprite = ImgContinue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (myCurrentScene != "start")
        {
            SpriteState spriteState1 = buttonStart.spriteState;
            spriteState1.highlightedSprite = ImgContinueSelect;
            buttonStart.spriteState = spriteState1;
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


//// Use this for initialization
//void Start()
//{
//    if (myCurrentScene != "start")
//    {
//        buttonStart.image.sprite = ImgContinue;
//    }

//}