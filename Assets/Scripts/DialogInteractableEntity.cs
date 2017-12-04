using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogInteractableEntity : InteractableEntity
{
    
    public Dialog[] dialogs;
    
    int currentDialog;
    int currentLine;

    Canvas canvasDialog;
    
    GameObject image;
    GameObject text;

    new void Awake()
    {
        base.Awake();

        canvasDialog = GameObject.Find("DialogueCanvas").GetComponent<Canvas>();
        image = canvasDialog.transform.Find("Image").gameObject;
        text = image.transform.Find("Text").gameObject;
        
        HideDialog();

        currentDialog = 0;
        currentLine = -1;
        //NextDialog();
    }

    public void NextDialog ()
    {
        if (dialogs.Length <= currentDialog + 1)
            return;

        currentDialog++;

        currentLine = -1;
        //NextLine();
    }

    public string NextLine ()
    {
        if (dialogs[currentDialog].lines.Length <= currentLine + 1)
            return dialogs[currentDialog].lines[currentLine];

        currentLine++;

        return dialogs[currentDialog].lines[currentLine];
    }

    public string GetCurrentLine()
    {
        return dialogs[currentDialog].lines[currentLine];
    }

    public bool IsLastLine()
    {
        return currentLine == dialogs[currentDialog].lines.Length - 1;
    }

    public override void Interact()
    {
        base.Interact();

        if (IsLastLine())
        {
            HideDialog();

            if (dialogs[currentDialog].loop)
            {
                currentLine = -1;
            }
            else if (dialogs[currentDialog].chain)
            {
                NextDialog();
            }
            
        }
        else
            DisplayDialog();
    }

    void DisplayDialog()
    {
        image.SetActive(true);
        text.SetActive(true);
        text.GetComponent<Text>().text = NextLine();
    }

    void HideDialog()
    {
        image.SetActive(false);
        text.SetActive(false);
    }

}

[System.Serializable]
public class Dialog
{
    public bool loop = false;
    public bool chain = false;
    public string[] lines;
}
