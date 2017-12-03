using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (Input.GetAxis("Action") == 1)
            SceneManager.LoadScene("main-menu");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
