using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [Header("References")]
    public GameObject dialogBox;
    public GameObject taskBox;
    public TMPro.TextMeshProUGUI dialogText;
    public AudioSource audio;
    public Image dialogSpeaker;
    public Image dialogPlayer;

    [Header("Lists")]
    public List<Sprite> characterSprites;
    public string[] npcNames;
    public Color[] alphaManager;

    [Header("Modifiers")]
    public KeyCode interactKey = KeyCode.E;
    public float normalSpeed = 0.03f;
    public float quickSpeed = 0;
    [HideInInspector] public float speed = 1;
    [HideInInspector] public Sprite lastSpeaker = null;

    //Privates
    private bool isActiveDialog = false;
    private List<string> dialogLinesQueue = new List<string>();
    private List<Sprite> dialogCharacterSpritesQueue = new List<Sprite>();
    private List<bool> isNpcTalkingBoolQueue = new List<bool>();


    private void Start()
    {
        speed = normalSpeed;
        StartCoroutine(ConversationManager());
    }

    void Update()
    {
        if (Input.GetKey(interactKey) && isActiveDialog) speed = quickSpeed;
        else if (!Input.GetKey(interactKey) && isActiveDialog) speed = normalSpeed;
    }

    /// <param name="spriteSpriteIndx">0: Dmitrii -- 1: Alba -- 2: Dani -- 3: Mario -- 4: Sam -- 5: Andrey -- 6: Alyta</param>
    public void NewDialog(string msg, int spriteSpriteIndx, bool npcTalking)
    { NewDialog(msg, characterSprites[spriteSpriteIndx], npcTalking); }

    /// <param name="spriteSpriteIndx">0: Dmitrii -- 1: Alba -- 2: Dani -- 3: Mario -- 4: Sam -- 5: Andrey -- 6: Alyta</param>
    public void NewDialog(string[] msg, int spriteSpriteIndx, bool npcTalking)
    { NewDialog(msg, characterSprites[spriteSpriteIndx], npcTalking); }

    public void NewDialog(string msg, bool npcTalking) { NewDialog(msg, lastSpeaker, npcTalking); }
    public void NewDialog(string[] msg, bool npcTalking) { NewDialog(msg, lastSpeaker, npcTalking); }

    public void NewDialog(string msg, Sprite npcSprite, bool npcTalking)
    {
        NewDialog(new string[] {msg}, npcSprite, npcTalking);
    }
    public void NewDialog(string[] msg, Sprite npcSprite, bool npcTalking)
    {
        foreach (string line in msg)
        {
            dialogLinesQueue.Add(line);
            dialogCharacterSpritesQueue.Add(npcSprite);
            isNpcTalkingBoolQueue.Add(npcTalking);
        }
        lastSpeaker = npcSprite;
    }

    public void ResetDialogAnimators()
    {
        dialogPlayer.GetComponent<Animator>().SetBool("isFocused", false);
        dialogSpeaker.GetComponent<Animator>().SetBool("isFocused", false);
        dialogPlayer.GetComponent<Animator>().SetTrigger("Reset");
        dialogSpeaker.GetComponent<Animator>().SetTrigger("Reset");
    }

    public IEnumerator ConversationManager()
    {
        bool isConversation = false;

        while (true)
        {
            if (dialogLinesQueue.Count > 0 && !isConversation)
            {
                isConversation = true;
                dialogBox.SetActive(true);
                taskBox.GetComponent<Animator>().SetBool("isShown", false);
                Time.timeScale = 0;
            }
            else if (dialogLinesQueue.Count == 0 && isConversation && !isActiveDialog)
            {
                isConversation = false;
                dialogBox.SetActive(false);
                ResetDialogAnimators();
                taskBox.GetComponent<Animator>().SetBool("isShown", true);
                Time.timeScale = 1;
            }

            if (isConversation)
            {
                if (!isActiveDialog)
                {
                    string line = dialogLinesQueue[0];
                    Sprite npcSprite = dialogCharacterSpritesQueue[0];
                    bool isNpcTalking = isNpcTalkingBoolQueue[0];

                    if (npcSprite != null) dialogSpeaker.color = alphaManager[0];
                    else dialogSpeaker.color = alphaManager[1];
                    dialogSpeaker.sprite = npcSprite;

                    
                    string npcName = "";
                    if (npcSprite != null) npcName = npcNames[characterSprites.IndexOf(npcSprite)];
                    dialogSpeaker.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = npcName;

                    if (isNpcTalking)
                    {
                        dialogPlayer.GetComponent<Animator>().SetBool("isFocused", false);
                        dialogSpeaker.GetComponent<Animator>().SetBool("isFocused", true);
                    }
                    else
                    {
                        dialogSpeaker.GetComponent<Animator>().SetBool("isFocused", false);
                        dialogPlayer.GetComponent<Animator>().SetBool("isFocused", true);
                    }

                    isActiveDialog = true;
                    StartCoroutine(DisplayDialog(line));

                    dialogLinesQueue.RemoveAt(0);
                    dialogCharacterSpritesQueue.RemoveAt(0);
                    isNpcTalkingBoolQueue.RemoveAt(0);
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator DisplayDialog(string msg)
    {
        dialogText.text = "";
        foreach (char c in msg)
        {

            dialogText.text = dialogText.text + c;
            // playCharSound;

            yield return new WaitForSecondsRealtime(speed);
        }

        while (Input.GetKey(interactKey)) { yield return new WaitForEndOfFrame(); }
        while (!Input.GetKey(interactKey)) { yield return new WaitForEndOfFrame(); }
        while (Input.GetKey(interactKey)) { yield return new WaitForEndOfFrame(); }

        isActiveDialog = false;
    }
}

        
