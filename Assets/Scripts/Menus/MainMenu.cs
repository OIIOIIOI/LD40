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
        if (Input.GetButtonDown("Vertical"))
                menusound();
        if (Input.GetMouseButtonDown(0))
            menusound();

        if (Input.GetMouseButtonDown(1))
            menusound();

        if (Input.GetMouseButtonDown(2))
            menusound();

    }

    void menusound()
    {
        int note = Random.Range(1, 7);
            switch(note)
        {
            case 1:
                menu1.Play();
                break;
            case 2:
                menu2.Play();
                break;
            case 3:
                menu3.Play();
                break;
            case 4:
                menu4.Play();
                break;
            case 5:
                menu5.Play();
                break;
            case 6:
                menu6.Play();
                break;
            case 7:
                menu7.Play();
                break;
                
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
        SceneManager.LoadScene(1);
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