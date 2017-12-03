using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoardMenu : MonoBehaviour {
    public bool isActive=false;
    public Button selectedBtn;
    public Button NonSelectedBtn;

	// Use this for initialization
	void Start () {
        if (isActive)
        {
            //Set the navigation to the default value. ("Automatic" is the default value).
            selectedBtn.navigation = Navigation.defaultNavigation;

        }

        if (isActive == true)
        {
            //Set the navigation to the default value. ("Automatic" is the default value).
            selectedBtn.navigation = Navigation.defaultNavigation;

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
