using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialog : MonoBehaviour {

    public DialogInteractableEntity dial;

	// Use this for initialization
	void Start () {
        dial = gameObject.GetComponent<DialogInteractableEntity>();
        Debug.Log(dial.GetCurrentLine());
        Debug.Log(dial.NextLine());
        Debug.Log(dial.NextLine());

        dial.NextDialog();
        Debug.Log(dial.GetCurrentLine());
        Debug.Log(dial.NextLine());
        Debug.Log(dial.NextLine());
        Debug.Log(dial.NextLine());
        Debug.Log(dial.NextLine());
        Debug.Log(dial.NextLine());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
