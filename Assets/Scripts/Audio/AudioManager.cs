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
    [SerializeField] AudioSource blablaSource;
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
    private void Update()
    {
        //if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) StopStepSound();
        //if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) StopStepSound();
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
        await Task.Delay(5500);
        Debug.Log("Something is wrong ! ");
        introSound.Stop();
        somethingWentWrongAudio.Play();
    }

    public void PlayBlablaSound(int speakerIndex)
    {
        blablaSource.Stop();
        blablaConfig = blablaConfigs[speakerIndex];
        blablaSource.clip = blablaConfig.GetRandomClip();
        blablaSource.pitch = blablaConfig.GetRandomPitch();
        blablaSource.PlayOneShot(blablaSource.clip);
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
        stepSounds[randomIndex].Stop();
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
        if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D)
            | Input.GetKey(KeyCode.LeftArrow) | Input.GetKey(KeyCode.RightArrow)) {

            randomIndex = Random.Range(0, stepSounds.Count);
            stepSounds[randomIndex].pitch = GetRandomPitch();
            stepSounds[randomIndex].Play();
        }
    }
    #endregion
}
