using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogInteractableEntity : InteractableEntity
{
    
    public Dialog[] dialogs;

    int currentDialog;
    int currentLine;

    void Awake()
    {
        currentDialog = -1;
        currentLine = -1;
        NextDialog();
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

}

[System.Serializable]
public class Dialog
{
    public string[] lines;
}
