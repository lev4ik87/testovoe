using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

public class ChangeScoreModel : MonoBehaviour
{
    private int scoreCountValue;

   [Inject] private ScoreController scoreController;


    private void OnEnable()
    {
        scoreController.OnScoreChangeModel += ChangeScore;
        CheckLineColor.OnGameOver += ResetScore;
    }
    private void OnDisable()
    {
        scoreController.OnScoreChangeModel -= ChangeScore;
        CheckLineColor.OnGameOver -= ResetScore;     
    }


    private void ChangeScore(int score)
    {
        scoreCountValue += score;
        scoreCountValue = Mathf.Clamp(scoreCountValue, 0, 999999);
        scoreController.SetTotalScore(scoreCountValue);    
    }

    private void ResetScore()
    {
        scoreCountValue = 0;    
    } 
}
