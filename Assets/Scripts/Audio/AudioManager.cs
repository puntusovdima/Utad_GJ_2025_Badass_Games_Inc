using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] float stepSoundRate;
    bool playingStepSounds;
    int randomIndex = 0;
    [Header("Sounds")]
    [SerializeField] AudioSource introSound;
    [SerializeField] List<AudioSource> stepSounds = new List<AudioSource>();
    [SerializeField] List<AudioSource> blablaSounds = new List<AudioSource>();
    [SerializeField] AudioSource somethingWentWrongAudio;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource interactSound;
    [SerializeField] AudioSource pressedButtonSound;
    [SerializeField] List<AudioSource> computerSounds = new List<AudioSource>();
    [SerializeField] List<BlablaConfig> blablaConfigs = new List<BlablaConfig>();
    BlablaConfig blablaConfig;

    private void Awake()
    {
        if (instance == null) instance = this;

        //A List of public methods:
        //PlayIntroSound();
        //PlayStepSound();
        //StopStepSound();

        //PlayJumpSound();
        //PlayInteractSound();
        //PlayPressButtonSound();
        //PlayBlaBlaMale();
        //PlayBlaBlaFemale();

        //PlayComputerStartUpSound();
        //PlayComputerShutDownSound();
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
        await Task.Delay(11000);
        Debug.Log("Something is wrong ! ");
        somethingWentWrongAudio.Play();
        await Task.Delay(3500);
        Debug.Log("The protagonist appears and starts speaking... ");
        blablaSounds[0].Play();
    }

    public void SetBlablaSound(int configNumber, AudioSource blablaSource)
    {
        blablaConfig = blablaConfigs[configNumber];
        blablaSource.clip = blablaConfig.GetRandomClip();
        blablaSource.pitch = blablaConfig.GetRandomPitch();
    }
    public void PlayJumpSound()
    {
        jumpSound.Play();
    }
    public void PlayInteractSound()
    {
        interactSound.Play();
    }
    public void PlayPressButtonSound()
    {
        pressedButtonSound.Play();
    }
    public async void PlayComputerStartUpSound()
    {
        computerSounds[0].volume = 1f;
        computerSounds[0].Play();
        await Task.Delay(3000);
        computerSounds[1].Play();
        await Task.Delay(1200);
        computerSounds[0].volume = 0.6f;
        await Task.Delay(500);
        computerSounds[0].volume = 0.3f;
        await Task.Delay(200);
        computerSounds[0].volume = 0.1f;
        await Task.Delay(200);
        computerSounds[0].volume = 0f;
    }
    public void PlayComputerShutDownSound()
    {
        computerSounds[2].Play();
    }

    #region step sounds
    public void StopStepSound()
    {
        if (!playingStepSounds) return;
        playingStepSounds = false;
        CancelInvoke("StepSoundRepetition");
    }
    public void PlayStepSound()
    {
        if (playingStepSounds) return;
        playingStepSounds = true;
        InvokeRepeating("StepSoundRepetition", 0f, stepSoundRate);
    }
    void StepSoundRepetition()
    {
        //Debug.Log("Play sound step " + randomIndex);
        randomIndex = Random.Range(0, stepSounds.Count);
        stepSounds[randomIndex].pitch = GetRandomPitch();
        stepSounds[randomIndex].Play();
    }
    #endregion
}
