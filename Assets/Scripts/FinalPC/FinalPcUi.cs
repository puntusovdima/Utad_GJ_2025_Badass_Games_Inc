using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class FinalPcUi : MonoBehaviour
{
    // public Image[] Images;
    private bool laptopIsOn = false;
    public Image laptopImage;
    // public Image onButtonImage;
    public GameObject SendButton;
    public Image SendButtonImage;
    public Sprite[] SendButtonSprites;
    // public Sprite[] onButtonSprites;
    public Sprite[] sprites;
    public Animator anim;

    public float loadWindowsDelay = 1.7f;
    private readonly int AlmostMidnight = Animator.StringToHash("AlmostMidnight");

    private void Start()
    {
        anim = GetComponent<Animator>();
        //OpenLaptop();
    }

    public void OpenLaptop()
    {
        // onButtonImage.sprite = onButtonSprites[0];
        gameObject.SetActive(true);
        Time.timeScale = 1;
        // Debug.Log("Opening laptop");
        StartTheComputer();
    }
    public void StartTheComputer()
    {
        // laptopIsOn = !laptopIsOn;
        // if (laptopIsOn)
        // {
            // onButtonImage.sprite = onButtonSprites[0];
            laptopImage.sprite = sprites[0];
            StartCoroutine(LoadWindows(loadWindowsDelay));
        // }
        // else
        // {
        //     StopAllCoroutines();
        //     SendButton.SetActive(false);
        //     onButtonImage.sprite = onButtonSprites[2];
        //     laptopImage.sprite = sprites[4];
        // }
    }

    private IEnumerator LoadWindows(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        laptopImage.sprite = sprites[1];
        // onButtonImage.sprite = onButtonSprites[1];
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

    public async void SendGame()
    {
        laptopImage.sprite = sprites[4];
        anim.SetTrigger(AlmostMidnight);
        SendButtonImage.sprite = SendButtonSprites[2];
        SendButton.SetActive(false);
        // call the finish game logic here
        await Task.Delay(10000);
        FinishTheGame();
    }

    public void FinishTheGame()
    {
        Debug.Log("Congratulations! You passed the game!");
        laptopImage.sprite = sprites[4];
        gameObject.SetActive(false);
        SceneManager.LoadScene(4);
    }
}
