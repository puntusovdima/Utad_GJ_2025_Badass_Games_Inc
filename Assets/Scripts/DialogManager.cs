using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [Header("References")]
    public GameObject dialogBox;
    public TMPro.TextMeshProUGUI dialogText;
    public Image dialogSpeaker;

    [Header("Sprites")]
    public Sprite[] characterSprites;

    [Header("Modifiers")]
    public KeyCode interactKey = KeyCode.E;
    public float normalSpeed;
    public float quickSpeed;
    [HideInInspector] public float speed = 1;

    private bool isActiveDialog = false;

    private void Start()
    {
        speed = normalSpeed;
    }

    void Update()
    {
        
    }

    public void NewDialog(string msg, int spriteSpriteIndx)
    { NewDialog(msg, characterSprites[spriteSpriteIndx]); }

    /// <param name="npcSprite">int [0, 6]</param>
    public void NewDialog(string msg, Sprite npcSprite)
    {
        NewDialog(new string[] {msg}, npcSprite);
    }

    /// <param name="npcSprite">int [0, 6]</param>
    public void NewDialog(string[] msg, int spriteSpriteIndx)
    { NewDialog(msg, characterSprites[spriteSpriteIndx]); }
    public void NewDialog(string[] msg, Sprite npcSprite)
    {
        dialogBox.SetActive(true);
        Time.timeScale = 0;
        isActiveDialog = true;
        dialogSpeaker.sprite = npcSprite;
        StartCoroutine(DisplayDialog(msg));
    }

    public IEnumerator DisplayDialog(string[] msg)
    {
        foreach (string line in msg)
        {
            dialogText.text = "";
            foreach (char c in line)
            {
                dialogText.text = dialogText.text + c;
                // playCharSound;

                yield return new WaitForSecondsRealtime(speed);
            }

            while (Input.GetKey(interactKey)) { yield return new WaitForEndOfFrame(); }
            while (!Input.GetKey(interactKey)) { yield return new WaitForEndOfFrame(); }
            while (Input.GetKey(interactKey)) { yield return new WaitForEndOfFrame(); }
        }

        dialogBox.SetActive(false);
        isActiveDialog = false;
        Time.timeScale = 0;
    }
}
