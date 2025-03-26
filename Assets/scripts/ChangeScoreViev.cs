using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ChangeScoreViev : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI endGameScoreText;
    [SerializeField] private GameObject scoreController;

 
    private void OnEnable()
    {   
        scoreController.GetComponent<IScoreChangeViev>().OnScoreChangeViev += ChangeScoreText;
        CheckLineColor.OnGameOver += ChangeScoreTextToZero;
    }
    private void OnDisable()
    {
        scoreController.GetComponent<IScoreChangeViev>().OnScoreChangeViev -= ChangeScoreText;
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
