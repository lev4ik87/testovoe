using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Zenject;

public class ChangeScoreViev : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI endGameScoreText;
    [Inject] private ScoreController scoreController;


    private void OnEnable()
    { 
        scoreController.OnScoreChangeViev += ChangeScoreText;
        CheckLineColor.OnGameOver += ChangeScoreTextToZero;
    }
    private void OnDisable()
    {
        scoreController.OnScoreChangeViev -= ChangeScoreText;
        CheckLineColor.OnGameOver -= ChangeScoreTextToZero;
    }

    private void ChangeScoreText(int totalScore)
    {
        scoreText.text = totalScore.ToString();
        endGameScoreText.text = totalScore.ToString();
    }

    private void ChangeScoreTextToZero()
    {
        scoreText.text = "0";
    }

}
