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
    public AudioSource audioLoop;
    public AudioSource menu1;
    public AudioSource menu2;
    public AudioSource menu3;
    public AudioSource menu4;
    public AudioSource menu5;
    public AudioSource menu6;
    public AudioSource menu7;

    // SpriteState spriteState1 = new SpriteState();

    // Use this for initialization
    void Start () {
        if (myCurrentScene != "start")
        {
            buttonStart.image.sprite = ImgContinue;
        }
        audioLoop.Play();

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
        if (Input.GetKey("up"))
            Debug.Log("up arrow key is held down");
        if (Input.GetKey("down"))
            Debug.Log("up arrow key is held down");
        if(Input.GetKey("up"))
            Debug.Log("up arrow key is held down");
        if (Input.GetMouseButtonDown(0))
            Debug.Log("Pressed left click.");

        if (Input.GetMouseButtonDown(1))
            Debug.Log("Pressed right click.");

        if (Input.GetMouseButtonDown(2))
            Debug.Log("Pressed middle click.");

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