using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] float stepSoundRate;
    int randomIndex = 0;
    [Header("Sounds")]
    [SerializeField] AudioSource introSound;
    [SerializeField] List<AudioSource> stepSounds = new List<AudioSource>();
    [SerializeField] List<AudioSource> blablaSounds = new List<AudioSource>();
    [SerializeField] AudioSource somethingWentWrongAudio;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource interactSound;
    [SerializeField] AudioSource pressedButtonSound;
    [SerializeField] AudioSource computerSound;

    private void Awake()
    {
        if (instance == null) instance = this;
        //PlayIntroSound();
        //PlayStepSound();
        //StopStepSound();
        //PlayJumpSound();
        //PlayBlaBlaMale();
        //PlayBlaBlaFemale();
    }


    #region helper functions
    float GetRandomPitch()
    {
        return Random.Range(1f, 1.8f);
    }
    #endregion



    public async void PlayIntroSound()
    {
        introSound.Play();
        Debug.Log("Logo appears");
        await Task.Delay(17000);
        Debug.Log("Something is wrong ! ");
        somethingWentWrongAudio.Play();
        await Task.Delay(3500);
        Debug.Log("The protagonist appears and starts speaking... ");
        blablaSounds[0].Play();
    }

    public void PlayBlaBlaMale()
    {
        blablaSounds[0].pitch = GetRandomPitch();
        blablaSounds[0].Play();
    }
    public void PlayBlaBlaFemale()
    {
        blablaSounds[1].pitch = GetRandomPitch();
        blablaSounds[1].Play();

    }
    public void PlayJumpSound()
    {
        jumpSound.Play();
    }
    public void PlayInteractSound()
    {

    }

    #region step sounds
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
    #endregion
}
