using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogInteractableEntity : InteractableEntity
{
    
    public Dialog[] dialogs;
    
    int currentDialog;
    int currentLine;

    public Canvas canvasDialog;

    Image image;

    new void Awake()
    {
        base.Awake();

        image = canvasDialog.transform.Find("Image").GetComponent<Image>();
        image.enabled = false;

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
        NextLine();
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
        DisplayDialog();
    }

    void DisplayDialog()
    {
        image.enabled = true;
        image.transform.GetComponent<Text>().text = NextLine();
    }

    void HideDialog()
    {
        image.enabled = false;
    }

}

[System.Serializable]
public class Dialog
{
    public string[] lines;
}
