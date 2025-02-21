using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] float stepSoundRate;
    [SerializeField] AudioSource introSound;
    [SerializeField] AudioSource stepSound;
    private void Awake()
    {
        if (instance == null) instance = this;
    }


    public void PlayIntroSound()
    {
        introSound.Play();
    }
    public void StopStepSound()
    {
        CancelInvoke("StepSoundRepetition");
    }
    public void PlayStepSound()
    {
        InvokeRepeating("StepSoundRepetition", 0f, stepSoundRate);
    }
    void StepSoundRepetition()
    {
        stepSound.Play();
    }
}
