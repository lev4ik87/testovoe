using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ChangeScoreViev : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI scoreText;
     private IScoreChangeViev scoreController;
  
    private void OnEnable()
    {
        scoreController = ScoreController.link;
        scoreController.OnScoreChangeViev += ChangeScoreText;
    }
    private void OnDisable()
    {
        scoreController.OnScoreChangeViev -= ChangeScoreText;
    }

    private void ChangeScoreText(int totalScore)
    {
        scoreText.text = totalScore.ToString();
    }
}
