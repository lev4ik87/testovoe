using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ChangeScoreViev : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject scoreController;

 
    private void OnEnable()
    {   
        scoreController.GetComponent<IScoreChangeViev>().OnScoreChangeViev += ChangeScoreText;
    }
    private void OnDisable()
    {
        scoreController.GetComponent<IScoreChangeViev>().OnScoreChangeViev -= ChangeScoreText;
    }

    private void ChangeScoreText(int totalScore)
    {
        scoreText.text = totalScore.ToString();
    }
}
