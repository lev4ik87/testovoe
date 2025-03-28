using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;
public class ScoreSphere: MonoBehaviour
{
    [SerializeField]private int scoreValue;

    [Inject] private ScoreController scoreController;

  

    public void AddScore()
    {   
        scoreController.ChangeScoreModel(scoreValue);
    }

    public void RemoveScore()
    {
        scoreController.ChangeScoreModel(-scoreValue);
    } 
}
