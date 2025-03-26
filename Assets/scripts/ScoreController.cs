using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreController : MonoBehaviour,IScoreChangeController, IScoreChangeModel, ISetTotalScore, IScoreChangeViev
{
    private int totalScore;
    public static ScoreController link;
   

    public event Action<int> OnScoreChangeModel;
    public event Action<int> OnScoreChangeViev;

    private void Awake()
    {
        link = this;
    }

    void IScoreChangeController.ChangeScore(int score)
    {
        OnScoreChangeModel.Invoke(score);
    }

    void ISetTotalScore.SetTotalScore(int score)
    {
        totalScore = score;
        ScoreChangeViev();
    }

    private void ScoreChangeViev()
    {
        OnScoreChangeViev.Invoke(totalScore);
    }
}

