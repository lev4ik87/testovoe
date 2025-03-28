using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ScoreController : MonoBehaviour
{
    private int totalScore;

    public event Action<int> OnScoreChangeModel;
    public event Action<int> OnScoreChangeViev;

   

    public  void ChangeScoreModel(int score)
    {
        OnScoreChangeModel.Invoke(score);
    }

   

    private void ScoreChangeViev()
    {
        OnScoreChangeViev.Invoke(totalScore);
    }


    public void SetTotalScore(int score)
    {
        totalScore = score;
        ScoreChangeViev();
    }
}

