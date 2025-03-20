
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField]private GameObject mainMenuCanvas; 
    [SerializeField]private GameObject playGameCanvas; 
    [SerializeField]private GameObject gameOverCanvas;

    private void OnEnable()
    {
        CheckTriggerColors.OnGameOver += GameOver; 
    }
    private void OnDisable()
    {
        CheckTriggerColors.OnGameOver -= GameOver;
    }

    public void MainMenu()
    {
        gameOverCanvas.SetActive(false);
        playGameCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    public void PlayGame()
    {
        mainMenuCanvas.SetActive(false);
        playGameCanvas.SetActive(true);   
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        playGameCanvas.SetActive(false);  
    }

    public void Restart()
    {
        gameOverCanvas.SetActive(false);
        playGameCanvas.SetActive(true);
    }
}
