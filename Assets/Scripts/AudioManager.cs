using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] float stepSoundRate;
    int randomIndex = 0;
    [Header("Sounds")]
    [SerializeField] AudioSource introSound;
    [SerializeField] List<AudioSource> stepSounds = new List<AudioSource>();

    private void Awake()
    {
        if (instance == null) instance = this;
        PlayStepSound();
    }


    #region helper functions
    float GetRandomPitch()
    {
        return Random.Range(1f, 1.8f);
    }
    #endregion



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
        Debug.Log("Play sound step " + randomIndex);
        randomIndex = Random.Range(0, stepSounds.Count);
        stepSounds[randomIndex].pitch = GetRandomPitch();
        stepSounds[randomIndex].Play();
    }
}
