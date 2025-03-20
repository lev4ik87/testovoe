using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SphereScore : MonoBehaviour
{
    [SerializeField]private int scoreValue;

    public static event Action<int> OnAddScore;

   public void AddScore()
    {
        OnAddScore?.Invoke(scoreValue);
    }

    public void RemoveScore()
    {
        OnAddScore?.Invoke(-scoreValue);
    }
}
