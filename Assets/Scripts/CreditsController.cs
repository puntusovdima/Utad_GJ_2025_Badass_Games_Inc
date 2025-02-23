using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CreditsController : MonoBehaviour
{
    [SerializeField] GameObject imageBackground;
    [SerializeField] GameObject authorsCredits;
    [SerializeField] GameObject soundsCredits;

    async void Start()
    {
        await Task.Delay(9500);
        imageBackground.SetActive(true);
        authorsCredits.SetActive(true);
        await Task.Delay(6000);
        authorsCredits.SetActive(false);
        soundsCredits.SetActive(true);
    }
}
