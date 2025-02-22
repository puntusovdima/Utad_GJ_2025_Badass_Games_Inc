using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FinalPcUi : MonoBehaviour
{
    // public Image[] Images;
    private bool laptopIsOn = false;
    public Image laptopImage;
    public Image onButtonImage;
    public GameObject SendButton;
    public Image SendButtonImage;
    public Sprite[] SendButtonSprites;
    public Sprite[] onButtonSprites;
    public Sprite[] sprites;
    public Animator anim;

    public float loadWindowsDelay = 1.7f;
    private readonly int AlmostMidnight = Animator.StringToHash("AlmostMidnight");

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenLaptop()
    {
        // onButtonImage.sprite = onButtonSprites[0];
        gameObject.SetActive(true);
        // Debug.Log("Opening laptop");
    }
    public void StartTheComputer()
    {
        laptopIsOn = !laptopIsOn;
        if (laptopIsOn)
        {
            onButtonImage.sprite = onButtonSprites[0];
            laptopImage.sprite = sprites[0];
            StartCoroutine(LoadWindows(loadWindowsDelay));
        }
        else
        {
            StopAllCoroutines();
            SendButton.SetActive(false);
            onButtonImage.sprite = onButtonSprites[2];
            laptopImage.sprite = sprites[4];
        }
    }

    private IEnumerator LoadWindows(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        laptopImage.sprite = sprites[1];
        onButtonImage.sprite = onButtonSprites[1];
        SendButton.SetActive(true);
    }

    public void HoverTheButton(bool isHovering)
    {
        if (isHovering)
        {
            // laptopImage.sprite = sprites[2];
            SendButtonImage.sprite = SendButtonSprites[1];
        }
        else
        {
            // laptopImage.sprite = sprites[1];
            SendButtonImage.sprite = SendButtonSprites[0];
        }
    }

    public void SendGame()
    {
        anim.SetTrigger(AlmostMidnight);
        SendButtonImage.sprite = SendButtonSprites[2];
        SendButton.SetActive(false);
        // call the finish game logic here
    }

    public void FinishTheGame()
    {
        laptopImage.sprite = sprites[3];
        Debug.Log("Congratulations! You passed the game!");
    }
}
