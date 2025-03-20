using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDestoyObject : MonoBehaviour
{
    [SerializeField] int timerValue;

    private void OnEnable()
    {
        Destroy(gameObject, timerValue);
        CheckTriggerColors.OnGameOver += DestroyObject;
    }
    private void OnDisable()
    {
        CheckTriggerColors.OnGameOver -= DestroyObject;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
   


}
