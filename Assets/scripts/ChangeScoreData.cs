using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangeScoreData : MonoBehaviour
{
    private int scoreCountValue;

    private IScoreChangeData scoreChange;
   [SerializeField]  private GameObject scoreController;

  
    private void OnEnable()
    {
        scoreChange = scoreController.GetComponent<IScoreChangeData>();
        scoreChange.OnScoreChangeData += ChangeScore;
    }
    private void OnDisable()
    {
        scoreChange.OnScoreChangeData -= ChangeScore;
        ResetScore();
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
