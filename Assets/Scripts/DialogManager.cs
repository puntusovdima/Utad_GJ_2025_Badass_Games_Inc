using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [Header("References")]
    public GameObject dialogBox;
    public GameObject taskBox;
    public TMPro.TextMeshProUGUI dialogText;
    public Image dialogSpeaker;
    public Image dialogPlayer;

    [Header("Sprites")]
    public Sprite[] characterSprites;

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

    /// <param name="spriteSpriteIndx">int [0, 6]</param>
    public void NewDialog(string msg, int spriteSpriteIndx, bool npcTalking)
    { NewDialog(msg, characterSprites[spriteSpriteIndx], npcTalking); }

    /// <param name="spriteSpriteIndx">int [0, 6]</param>
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
    }

    public void ResetDialogAnimators()
    {
        dialogPlayer.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        dialogSpeaker.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
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

                    dialogSpeaker.sprite = npcSprite;
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

        
