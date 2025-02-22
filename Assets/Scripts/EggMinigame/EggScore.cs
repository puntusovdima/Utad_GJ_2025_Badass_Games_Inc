using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EggScore : MonoBehaviour
{   
    TMP_Text scoreText;
    public int score;

    private void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        InvokeRepeating("UpdateScore", 0, 0.2f);
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
