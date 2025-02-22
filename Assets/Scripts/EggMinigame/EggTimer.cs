using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EggTimer : MonoBehaviour
{
    TMP_Text timerText;
    public GameObject restartButton;
    public float totalTime = 100;

    private void Start()
    {
        Time.timeScale = 1;
        timerText = GetComponent<TMP_Text>();
    }
    private void Update()
    {
        if (totalTime <= 0)
        {
            totalTime = 0;
            Time.timeScale = 0;
            restartButton.SetActive(true);
        }
        totalTime -= Time.deltaTime;
        timerText.text = Math.Floor(totalTime).ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
