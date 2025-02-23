using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundIntro : MonoBehaviour
{
    public AudioManager audioManager;

    void Start()
    {
        audioManager.PlayIntroSound();
    }
}
