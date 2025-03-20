using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    private int scoreCountValue;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI scoreOverText;

    private void OnEnable()
    {
        SphereScore.OnAddScore += AddScore;
      
    }
    private void OnDisable()
    {
        SphereScore.OnAddScore -= AddScore;

        ScoreGameOverCanvas();
        ResetScore();
    }


    private void AddScore(int score)
    {
        scoreCountValue += score;
        scoreCountValue = Mathf.Clamp(scoreCountValue, 0, 999999);
        scoreText.text = scoreCountValue.ToString();
    }

    private void ResetScore()
    {
        scoreCountValue = 0;   
        scoreText.text = scoreCountValue.ToString();
    }

    private void ScoreGameOverCanvas()
    {
        scoreOverText.text = scoreCountValue.ToString();
    }


}
