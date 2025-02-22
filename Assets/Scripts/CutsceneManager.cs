using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] DialogManager dialogueManager;
    public static CutsceneManager instance;
    string[] dimaLines; //0
    string[] albaLines; //1
    string[] daniLines; //2
    string[] marioLines; //3
    string[] samLines; //4
    string[] andreyLines; //5
    string[] alytaLines; //6
    string[] senenLines; //7

    void Start()
    {
        if (instance == null) instance = this;
        //PlayCutscene1();
        //PlayCutscene2Mario();
        //PlayCutscene2Alba();
        //PlayCutscene2Andrey();
        //PlayCutscene2Alyta();
        //PlayCutscene2Dmitrii();
        //PlayCutscene2Sam();
        //PlayCutscene2Dani();
        //PlayCutscene2EndMonologue();
        //PlayCutscene3();
        //PlayCutscene4Library();
        //PlayCutscene4AfterExplosion();


    }

    //it's in order of appearence,
    //(order from the script document) : top to down:
    public void PlayCutscene1()
    {
        senenLines = new string[] {
        "Wait! Wait! What’s going on here?!",
        "It is not supposed to be like this! We didn’t even finish the core mechanics! Why intro already started?!",
        "It’s a disaster. We must step on the gas!",
        "We are absolutely out of time!!!",
        "I have to tell others…",
        "Hey, guys… we have the problem…"
        };
        dialogueManager.NewDialog(senenLines, null, false);

        alytaLines = new string[] {
        "What’s happened?"
        };
        dialogueManager.NewDialog(alytaLines, 6, true);

        senenLines = new string[] {
        "Well...",
        "Did you see the time?"
        };
        dialogueManager.NewDialog(senenLines, null, false);

        dimaLines = new string[] {
        "Yes. And?"
        };
        dialogueManager.NewDialog(dimaLines, 0, true);

        senenLines = new string[] {
        "Don’t you see?! We’re out of time!",
        "...",
        "Okay. Let me see what we already have"
        };
        dialogueManager.NewDialog(senenLines, null, false);
    }

    #region cutscene 2 - dialogues with team members and Senen monologue
    public void PlayCutscene2Mario()
    {
        senenLines = new string[] {
        "Hey. How is the game going?"
        };
        dialogueManager.NewDialog(senenLines, null, false);

        marioLines = new string[] {
        "Pretty well. We have almost finished the crouching mechanic"
        };
        dialogueManager.NewDialog(marioLines, 3, true);

        senenLines = new string[] {
        "But… we don’t even have this mechanic in the game"
        };
        dialogueManager.NewDialog(senenLines, null, false);
    }
    public void PlayCutscene2Alba()
    {
        senenLines = new string[] {
        "Hello. How are the animators doing?"
        };
        dialogueManager.NewDialog(senenLines, null, false);

        albaLines = new string[] {
        "Hi! Amazing! We are drawing the squirrels"
        };
        dialogueManager.NewDialog(albaLines, 1, true);

        senenLines = new string[] {
        "But the game is about an apple. Why did you th…?"
        };
        dialogueManager.NewDialog(senenLines, null, false);
    }
    public void PlayCutscene2Andrey()
    {
        senenLines = new string[] {
        "Tell me something good, please"
        };
        dialogueManager.NewDialog(senenLines, null, false);

        andreyLines = new string[] {
        "Great news! I made 5 hours of ASMR whisper!"
        };
        dialogueManager.NewDialog(andreyLines, 5, true);

        senenLines = new string[] {
        "What the f…"
        };
        dialogueManager.NewDialog(senenLines, null, false);
    }
    public void PlayCutscene2Alyta()
    {
        senenLines = new string[] {
        "Alyta. Tell me, that the things are under control"
        };
        dialogueManager.NewDialog(senenLines, null, false);

        alytaLines = new string[] {
        "Oh, absolutely. Actually, I just realized, that our idea is not enough good, so we have to fully change the whole concept, and I have a brilliant idea for it!"
        };
        dialogueManager.NewDialog(alytaLines, 6, true);

        senenLines = new string[] {
        "..."
        };
        dialogueManager.NewDialog(senenLines, null, false);

        alytaLines = new string[] {
        "Are you fine? You’re looking a little pale"
        };
        dialogueManager.NewDialog(alytaLines, 6, true);
    }
    public void PlayCutscene2Dmitrii()
    {
        dimaLines = new string[] {
        "Don’t touch me, please. I’m depressed and really want OJ"
        };
        dialogueManager.NewDialog(dimaLines, 0, true);

        senenLines = new string[] {
        "What is an “OJ”…?"
        };
        dialogueManager.NewDialog(senenLines, null, false);
    }
    public void PlayCutscene2Sam()
    {
        samLines = new string[] {
        "kcevgrfhjq"
        };
        dialogueManager.NewDialog(samLines, 4, true);

        senenLines = new string[] {
        "Okay… I guess"
        };
        dialogueManager.NewDialog(senenLines, null, false);
    }
    public void PlayCutscene2Dani()
    {
        daniLines = new string[] {
        "…"
        };
        dialogueManager.NewDialog(daniLines, 2, true);

        senenLines = new string[] {
        "Better not to touch him"
        };
        dialogueManager.NewDialog(senenLines, null, false);
    }


    //After the player talked to everyone, this will activate?
    public void PlayCutscene2EndMonologue()
    {
        senenLines = new string[] {
        "This is absolute mess. I must see the prototype myself",
        "My computer is in another room. Let’s see, what do we have for now"
        };
        dialogueManager.NewDialog(senenLines, null, false);
    }
    #endregion

    public void PlayCutscene3()
    {
        senenLines = new string[] {
        "Jesus Christ! This is horrible! What did these guys do?!",
        "I have to talk seriously with them"
        };
        dialogueManager.NewDialog(senenLines, null, false);
    }

    public void PlayCutscene4Library()
    {
        senenLines = new string[] {
        "Guys. We must talk",
        "What’s going on?"
        };
        dialogueManager.NewDialog(senenLines, null, false);

        marioLines = new string[] {
        "What do you mean?",
        };
        dialogueManager.NewDialog(marioLines, 3, true);

        senenLines = new string[] {
        "I mean, it’s already nine! We have to send project before midnight!"
        };
        dialogueManager.NewDialog(senenLines, null, false);

        dimaLines = new string[] {
        "Hey, bro. Calm down. We have plenty of time",
        };
        dialogueManager.NewDialog(dimaLines, 0, true);

        senenLines = new string[] {
        "Plenty of time?! Are you kidding me?!"
        };
        dialogueManager.NewDialog(senenLines, null, false);

        alytaLines = new string[] {
        "Hey, there is no need to be uncivil",
        };
        dialogueManager.NewDialog(alytaLines, 6, true);

        senenLines = new string[] {
        "You really don’t understand?!",
        "We’re going to fail if we are going work like this!"
        };
        dialogueManager.NewDialog(senenLines, null, false);

        albaLines = new string[] {
        "And who’s to blame?",
        };
        dialogueManager.NewDialog(albaLines, 1, true);

        senenLines = new string[] {
        "Obviously not me!"
        };
        dialogueManager.NewDialog(senenLines, null, false);

        dimaLines = new string[] {
        "And not me!",
        };
        dialogueManager.NewDialog(dimaLines, 0, true);

        samLines = new string[] {
        "ECFRUIDBNH!",
        };
        dialogueManager.NewDialog(samLines, 4, true);

        daniLines = new string[] {
        "...!",
        };
        dialogueManager.NewDialog(daniLines, 2, true);
    }
    public void PlayCutscene4AfterExplosion()
    {
        senenLines = new string[] {
        "Great… What am I supposed to do now?"
        };
        dialogueManager.NewDialog(senenLines, null, false);
    }
    public void PlayCutscene4Mario()
    {
        senenLines = new string[] {
        "Listen. I’m sorry. I think we all kinda… overwhelmed"
        };
        dialogueManager.NewDialog(senenLines, null, false);

        //

        senenLines = new string[] {
        "It’s not your fault",
        "Also, I started it, so…"
        };
        dialogueManager.NewDialog(senenLines, null, false);
    }
}
