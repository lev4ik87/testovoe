using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SphereColorDetect : MonoBehaviour, IResetTrigger
{
    [HideInInspector] public SphereColor.sphereColorsEnum detectColor;
    [HideInInspector] public GameObject sphere;
    protected static int countTriggerActive;

    protected Transform _transform;
    protected Collider2D[] colliderSphere;

    private void OnEnable()
    {
        CheckLineColor.OnGameOver += ResetTriggers;
        _transform = transform;  
    }
    private void OnDisable()
    {
        CheckLineColor.OnGameOver -= ResetTriggers;
    }

    protected abstract void DetectSphere(SphereColor _sphere);
 
    public static int GetCountTriggerActive()
    {
        return countTriggerActive;
    }

    protected void ResetTriggers()
    {
        countTriggerActive = 0;
        sphere = null;
        detectColor = SphereColor.sphereColorsEnum.empty;
    }

    void IResetTrigger.ResetTrigger()
    {
        sphere = null;
        detectColor = SphereColor.sphereColorsEnum.empty;
        countTriggerActive--; 
    }
}
