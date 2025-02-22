using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionsManager : MonoBehaviour
{
    public DialogManager DialogManager;
    public CutsceneManager CutsceneManager;

    string[] characterNames = { "Dmitrii", "Alba", "Dani", "Mario", "Sam", "Andrey", "Alyta" };
    StateManager stateManager;

    bool canComputer = false;
    bool justStarted = false;
    //string lastHitName = null;

    private void Start()
    {
        justStarted = true;
    }

    private void Update()
    {
        if (stateManager == null)
        {
            stateManager = GameObject.FindGameObjectWithTag("StateManager").GetComponent<StateManager>();

            if (justStarted)
            {
                justStarted = false;
            }
        }
        else
        {
            if (stateManager.state < 2 && stateManager.CheckIfSpokenWithAll() && !canComputer)
            {
                CutsceneManager.PlayCutscene2EndMonologue();
                canComputer = true;
            }
        }
    }

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
            if (npcName == name) break;
            else i++;
        }

        switch (npcName)
        {
            case "Dmitrii":
                Dmitrii(i);
                break;
            case "Alba":
                Alba(i);
                break;
            case "Dani":
                Dani(i);
                break;
            case "Mario":
                Mario(i);
                break;
            case "Sam":
                Sam(i);
                break;
            case "Andrey":
                Andrey(i);
                break;
            case "Alyta":
                Alyta(i);
                break;

        }
    }


    public void Dmitrii(int ind)
    {
        if (stateManager.state < 2)
        {
            CutsceneManager.PlayCutscene2Dmitrii();
        }
        else if (stateManager.state < 4)
        {
            CutsceneManager.PlayCutscene4Dmitrii();
        }

        stateManager.MarkAsSpoke(ind);
    }
    public void Alba(int ind)
    {
        if (stateManager.state < 2)
        {
            CutsceneManager.PlayCutscene2Alba();
        }
        else if (stateManager.state < 4)
        {
            CutsceneManager.PlayCutscene4Alba();
        }

        stateManager.MarkAsSpoke(ind);
    }
    public void Dani(int ind)
    {
        if (stateManager.state < 2)
        {
            CutsceneManager.PlayCutscene2Dani();
        }
        else if (stateManager.state < 4)
        {
            CutsceneManager.PlayCutscene4Dani();
        }

        stateManager.MarkAsSpoke(ind);
    }
    public void Mario(int ind)
    {
        if (stateManager.state < 2)
        {
            CutsceneManager.PlayCutscene2Mario();
        }
        else if (stateManager.state < 4)
        {
            CutsceneManager.PlayCutscene4Mario();
        }

        stateManager.MarkAsSpoke(ind);
    }
    public void Sam(int ind)
    {
        if (stateManager.state < 2)
        {
            CutsceneManager.PlayCutscene2Sam();
        }
        else if (stateManager.state < 4)
        {
            CutsceneManager.PlayCutscene4Sam();
        }

        stateManager.MarkAsSpoke(ind);
    }
    public void Andrey(int ind)
    {
        if (stateManager.state < 2)
        {
            CutsceneManager.PlayCutscene2Andrey();
        }
        else if (stateManager.state < 4)
        {
            CutsceneManager.PlayCutscene4Andrey();
        }

        stateManager.MarkAsSpoke(ind);
    }
    public void Alyta(int ind)
    {
        if (stateManager.state < 2)
        {
            CutsceneManager.PlayCutscene2Alyta();
        }
        else if (stateManager.state < 4)
        {
            CutsceneManager.PlayCutscene4Alyta();
        }

        stateManager.MarkAsSpoke(ind);
    }

    public void Computer()
    {
        if (canComputer)
        {
            canComputer = false;
            stateManager.ResetDialogs();

            if (stateManager.state < 2) {
                SetState(2);
                Camera.main.GetComponent<ComputerSceneTransition>().ZoomIn(2);
            }
            else if (stateManager.state < 4)
            {
                SetState(4);
                Camera.main.GetComponent<ComputerSceneTransition>().ZoomIn(3);
            }
        }
        else
        {
            if (stateManager.state < 2)
            {
                CutsceneManager.PlayCutscene2Wait();
            }
            else if (stateManager.state < 4)
            {
                CutsceneManager.PlayCutscene4Wait();
            }
        }
    }

    public void SetState(int state)
    {
        stateManager.state = state;
    }
    public int GetState()
    {
        return stateManager.state;
    }


    public void Intro()
    {
        CutsceneManager.PlayCutsceneIntro();
    }
    public void Begining()
    {
        CutsceneManager.PlayCutscene1();
    }
}
