using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SphereColorDetect : MonoBehaviour
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
        StartCoroutine("ColorDetectCor");

    }
    private void OnDisable()
    {
        CheckLineColor.OnGameOver -= ResetTriggers;
    }

    protected  IEnumerator ColorDetectCor()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            ColorDetect();     
        }
      
    }


    public abstract void ColorDetect();
  
  

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
}
