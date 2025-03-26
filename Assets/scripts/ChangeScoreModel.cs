using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangeScoreModel : MonoBehaviour
{
    private int scoreCountValue;

    private IScoreChangeModel scoreChange;
   [SerializeField]  private GameObject scoreController;

  
    private void OnEnable()
    {
        scoreChange = scoreController.GetComponent<IScoreChangeModel>();
        scoreChange.OnScoreChangeModel += ChangeScore;
        CheckLineColor.OnGameOver += ResetScore;
    }
    private void OnDisable()
    {
        scoreChange.OnScoreChangeModel -= ChangeScore;
        CheckLineColor.OnGameOver -= ResetScore;     
    }


    private void ChangeScore(int score)
    {
        scoreCountValue += score;
        scoreCountValue = Mathf.Clamp(scoreCountValue, 0, 999999);
        scoreController.GetComponent<ISetTotalScore>().SetTotalScore(scoreCountValue);    
    }

    private void ResetScore()
    {
        scoreCountValue = 0;    
    } 
}
