using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogInteractableEntity : InteractableEntity
{
    
    public Dialog[] dialogs;
    
    int currentDialog;
    int currentLine;

    new void Awake()
    {
        base.Awake();

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

    public string GetCurrentLine ()
    {
        return dialogs[currentDialog].lines[currentLine];
    }

    public override void Interact()
    {
        Debug.Log(NextLine());
        // TODO call dialog display
    }

}

[System.Serializable]
public class Dialog
{
    public string[] lines;
}
