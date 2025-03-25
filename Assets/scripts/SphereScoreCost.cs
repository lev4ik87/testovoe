using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SphereScoreCost : MonoBehaviour
{
    [SerializeField]private int scoreValue;

    private IScoreChangeController scoreController;

  
    private void Start()
    {
        scoreController = ScoreController.link;
    }

    public void AddScore()
    {   
        scoreController.ChangeScore(scoreValue);
    }

    public void RemoveScore()
    {
        scoreController.ChangeScore(-scoreValue);
    } 
}
