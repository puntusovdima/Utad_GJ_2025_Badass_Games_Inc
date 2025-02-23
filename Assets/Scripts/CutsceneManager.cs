using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] DialogManager dialogueManager;
    public TaskManager taskManager;
    public InteractionsManager interactionsManager;
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
        if (instance == null) { 
            instance = this;
            Debug.Log(name + " is in the scene !!");
        }

        //PlayCutsceneIntro();
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
        //PlayCutscene4Mario();
        //PlayCutscene4Alba();
        //PlayCutscene4Andrey();
        //PlayCutscene4Alyta();
        //PlayCutscene4Dmitrii();
        //PlayCutscene4Sam();
        //PlayCutscene4Dani();
        //PlayCutscene5()
        //PlayCutscene6()


    }

    //it's in order of appearence,
    //(order from the script document) : top to down:
    public void PlayCutsceneIntro()
    {
        senenLines = new string[] {
        "Wait! Wait! What’s going on here?!    (Press 'E' to continue)",
        "It's not supposed to be like this! We didn’t even finish the core mechanics yet! Why has the intro already started?!",
        "It’s a disaster. We must step on the gas!",
        "We are absolutely out of time!!!",
        "I have to tell the others…",
        };
        dialogueManager.NewDialog(senenLines, null, false);
    }

    public void PlayCutscene1()
    {
        dialogueManager.NewDialog("Hey, guys… we have a problem…", null, false);

        alytaLines = new string[] {
        "What’s happened?"
        };
        dialogueManager.NewDialog(alytaLines, 6, true);

        senenLines = new string[] {
        "Well...",
        "Did you see the time?"
        };
        dialogueManager.NewDialog(senenLines, false);

        dimaLines = new string[] {
        "Yes. And?"
        };
        dialogueManager.NewDialog(dimaLines, 0, true);

        senenLines = new string[] {
        "Don’t you see?! We’re out of time!",
        "...",
        "Okay. Let me see what we already have"
        };
        dialogueManager.NewDialog(senenLines, false);
    }

    #region cutscene 2 - dialogues with team members and Senen monologue
    public void PlayCutscene2Mario()
    {
        senenLines = new string[] {
        "Hey. How is the game going?"
        };
        dialogueManager.NewDialog(senenLines, 3, false);

        marioLines = new string[] {
        "Pretty well. We almost finished the crouching mechanic"
        };
        dialogueManager.NewDialog(marioLines, true);

        senenLines = new string[] {
        "But… we don’t even have this mechanic in the game"
        };
        dialogueManager.NewDialog(senenLines, false);
    }
    public void PlayCutscene2Alba()
    {
        senenLines = new string[] {
        "Hello. How are the animators doing?"
        };
        dialogueManager.NewDialog(senenLines, 1, false);

        albaLines = new string[] {
        "Hi! Amazing! We are drawing the squirrels"
        };
        dialogueManager.NewDialog(albaLines, true);

        senenLines = new string[] {
        "But the game is about an apple. Why did you…?",
        "Actually, nevermind"
        };
        dialogueManager.NewDialog(senenLines, false);
    }
    public void PlayCutscene2Andrey()
    {
        senenLines = new string[] {
        "Tell me something good, please"
        };
        dialogueManager.NewDialog(senenLines, 5, false);

        andreyLines = new string[] {
        "Great news! I made 5 hours of ASMR whisper!"
        };
        dialogueManager.NewDialog(andreyLines, true);

        senenLines = new string[] {
        "What the f…"
        };
        dialogueManager.NewDialog(senenLines, false);
    }
    public void PlayCutscene2Alyta()
    {
        senenLines = new string[] {
        "Alyta. Tell me, that the things are under control"
        };
        dialogueManager.NewDialog(senenLines, 6, false);

        alytaLines = new string[] {
        "Oh, absolutely. Actually, I just realized, that our idea is not good enough, so we have to fully change the whole concept, and I have a brilliant idea for it!"
        };
        dialogueManager.NewDialog(alytaLines, true);

        senenLines = new string[] {
        "..."
        };
        dialogueManager.NewDialog(senenLines, false);

        alytaLines = new string[] {
        "Are you fine? You’re looking a little pale"
        };
        dialogueManager.NewDialog(alytaLines, true);
    }
    public void PlayCutscene2Dmitrii()
    {
        dimaLines = new string[] {
        "Don’t touch me, please. I’m depressed and really want OJ"
        };
        dialogueManager.NewDialog(dimaLines, 0, true);

        senenLines = new string[] {
        "What's “OJ”…?"
        };
        dialogueManager.NewDialog(senenLines, false);
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
        dialogueManager.NewDialog(senenLines, false);
    }
    public void PlayCutscene2Dani()
    {
        daniLines = new string[] {
        "…"
        };
        dialogueManager.NewDialog(daniLines, 2, true);

        senenLines = new string[] {
        "Better don't touch him"
        };
        dialogueManager.NewDialog(senenLines, false);
    }


    //After the player talked to everyone, this will activate?
    public void PlayCutscene2EndMonologue()
    {
        senenLines = new string[] {
        "This is an absolute mess. I have to see the prototype myself",
        "My computer is on the far right. Let’s see what do we have for now"
        };
        dialogueManager.NewDialog(senenLines, null, false);

        taskManager.NewTask("· Check the playable prototype");
    }
    #endregion

    public void PlayCutscene3()
    {
        interactionsManager.SetState(3);
        senenLines = new string[] {
        "Jesus Christ! This is horrible! What did these guys do?!",
        "The game just cuts itself mid-game?",
        "I have to talk seriously with them.",
        "...",
        "Guys. We have to talk",
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
        dialogueManager.NewDialog(senenLines, false);

        dimaLines = new string[] {
        "Hey, bro. Calm down. We have plenty of time",
        };
        dialogueManager.NewDialog(dimaLines, 0, true);

        senenLines = new string[] {
        "Plenty of time?! Are you kidding me?!"
        };
        dialogueManager.NewDialog(senenLines, false);

        alytaLines = new string[] {
        "Hey, there's no need to be rude",
        };
        dialogueManager.NewDialog(alytaLines, 6, true);

        senenLines = new string[] {
        "Do you really not understand?!",
        "We’re gonna fail if we work like this!"
        };
        dialogueManager.NewDialog(senenLines, false);

        albaLines = new string[] {
        "And who’s to blame?",
        };
        dialogueManager.NewDialog(albaLines, 1, true);

        senenLines = new string[] {
        "Obviously not me!"
        };
        dialogueManager.NewDialog(senenLines, false);

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

        senenLines = new string[] {
        "What am I supposed to do now?"
        };
        dialogueManager.NewDialog(senenLines, null, false);

        taskManager.NewTask("· Speak with your colleagues");
    }
    public void PlayCutscene4Mario()
    {
        senenLines = new string[] {
        "Listen. I’m sorry. I think we're all kinda… overwhelmed"
        };
        dialogueManager.NewDialog(senenLines, 3, false);

        marioLines = new string[] {
        "Yes. Sorry. I didn't want to be rude"
        };
        dialogueManager.NewDialog(marioLines, true);

        senenLines = new string[] {
        "It’s not your fault",
        "Also, I started it, so…"
        };
        dialogueManager.NewDialog(senenLines, false);

        marioLines = new string[] {
        "Hey, cheer up. No one has died yet",
        "Let's continue working. We still can do it"
        };
        dialogueManager.NewDialog(marioLines, true);
    }

    public void PlayCutscene4Alba()
    {
        senenLines = new string[] {
        "Hey, Alba?"
        };
        dialogueManager.NewDialog(senenLines, 1, false);

        marioLines = new string[] {
        "Hey…"
        };
        dialogueManager.NewDialog(marioLines, true);

        senenLines = new string[] {
        "How are you?"
        };
        dialogueManager.NewDialog(senenLines, false);

        marioLines = new string[] {
        "It’s fine. I’m just kinda tired and sad that we didn’t make it as well as we could"
        };
        dialogueManager.NewDialog(marioLines, true);

        senenLines = new string[] {
        "Well, Dmitrii was actually right. We still have time.",
        "Not so much, but we have it."
        };
        dialogueManager.NewDialog(senenLines, false);

        marioLines = new string[] {
        "Yes, you’re right. Let’s try our best!"
        };
        dialogueManager.NewDialog(marioLines, true);
    }

    public void PlayCutscene4Andrey()
    {
        senenLines = new string[] {
        "Andrey?"
        };
        dialogueManager.NewDialog(senenLines, 5, false);

        marioLines = new string[] {
        "Hello. I’m sorry for misunderstanding"
        };
        dialogueManager.NewDialog(marioLines, true);

        senenLines = new string[] {
        "Ah, no. We all just didn’t really listen to each other.",
        "But do you still want to finish?"
        };
        dialogueManager.NewDialog(senenLines, false);

        marioLines = new string[] {
        "Oh, yes!"
        };
        dialogueManager.NewDialog(marioLines, true);

        senenLines = new string[] {
        "Then let’s do it!",
        };
        dialogueManager.NewDialog(senenLines, false);
    }

    public void PlayCutscene4Alyta()
    {
        senenLines = new string[] {
        "Hi. How are you?"
        };
        dialogueManager.NewDialog(senenLines, 6, false);

        marioLines = new string[] {
        "Good. A bit disappointed. Not in you, guys, but in a… work process."
        };
        dialogueManager.NewDialog(marioLines, true);

        senenLines = new string[] {
        "I guess, I understand."
        };
        dialogueManager.NewDialog(senenLines, false);

        marioLines = new string[] {
        "But I think it’s fine.",
        "After all, we joined it for experience",
        "And I think it’s a good one."
        };
        dialogueManager.NewDialog(marioLines, true);

        senenLines = new string[] {
        "Does it mean, that you’re ready to work?"
        };
        dialogueManager.NewDialog(senenLines, false);

        marioLines = new string[] {
        "Oh, yes. More obstacles – more fun. Let’s go!"
        };
        dialogueManager.NewDialog(marioLines, true);
    }

    public void PlayCutscene4Dmitrii()
    {
        marioLines = new string[] {
        "I know, what are you going to say. I’m fine. But honestly, I still want my OJ."
        };
        dialogueManager.NewDialog(marioLines, 0, true);

        senenLines = new string[] {
        "..."
        };
        dialogueManager.NewDialog(senenLines, false);
    }

    public void PlayCutscene4Sam()
    {
        senenLines = new string[] {
        "Hey Sam..."
        };
        dialogueManager.NewDialog(senenLines, 4, false);

        marioLines = new string[] {
        "Awfreiaunfg"
        };
        dialogueManager.NewDialog(marioLines, true);

        senenLines = new string[] {
        "Absolutely agree."
        };
        dialogueManager.NewDialog(senenLines, false);
    }

    public void PlayCutscene4Dani()
    {
        senenLines = new string[] {
        "..."
        };
        dialogueManager.NewDialog(senenLines, 2, false);

        marioLines = new string[] {
        "..."
        };
        dialogueManager.NewDialog(marioLines, true);

        senenLines = new string[] {
        "..."
        };
        dialogueManager.NewDialog(senenLines, false);
    }

    public void PlayCutscene5()
    {
        dialogueManager.NewDialog("It’s time to check the result.", null, false);
        taskManager.NewTask("· Playtest the last version of your game");
    }

    public void PlayCutscene6()
    {
        interactionsManager.SetState(5);

        senenLines = new string[] {
        "We actually did a great job. I have to tell everyone that we can send it.",
        "Guys...",
        "...",
        "Oh...",
        "They have all fallen asleep...",
        "Oh no! The time! I have to send the project!"
        };
        dialogueManager.NewDialog(senenLines, null, false);
    }

    public void PlayCutscene2Wait()
    {
        dialogueManager.NewDialog("I should check how everyone's doing before playing...", null, false);
    }
    public void PlayCutscene4Wait()
    {
        dialogueManager.NewDialog("This is a mess, everyone needs to continue working or there'll be no game at all!!!", null, false);
    }
}
