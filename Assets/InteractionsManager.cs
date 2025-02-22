using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractionsManager : MonoBehaviour
{
    public DialogManager DialogManager;
    string[] characterNames = { "Dmitrii", "Alba", "Dani", "Mario", "Sam", "Andrey", "Alyta" };
    //string lastHitName = null;

    public void Manager(string hitName)
    {
        if (Input.GetKeyDown(KeyCode.E) && !DialogManager.dialogBox.activeSelf)
        {
            print(hitName);

            if (hitName == "Computer") Computer();
            else if (characterNames.Contains(hitName)) DialogController(hitName);
        }
    }

    public void DialogController(string npcName)
    {
        int i = 0;
        foreach (string name in characterNames)
        {
            if (name == npcName) break;
            else i++;
        }

        DialogManager.NewDialog("Hi! My name is " + npcName, i, true);
    }


    public void Dmitrii()
    {

    }
    public void Alba()
    {

    }
    public void Dani()
    {

    }
    public void Mario()
    {

    }
    public void Sam()
    {

    }
    public void Andrey()
    {

    }
    public void Alyta()
    {

    }

    public void Computer()
    {
        Camera.main.GetComponent<ComputerSceneTransition>().ZoomIn(0);
    }
}
