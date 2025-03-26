using UnityEngine;

public abstract class SphereColorDetect : MonoBehaviour
{
    /*[HideInInspector]*/
    public SphereColor.sphereColorsEnum detectColor;
    /*[HideInInspector] */
    public GameObject sphere;
    protected static int countTriggerActive;

    protected Transform _transform;
    protected Collider2D[] colliderSphere;

    private void OnEnable()
    {
        CheckLineColor.OnGameOver += EndGameResetTriggers;
        _transform = transform;
    }
    private void OnDisable()
    {
        CheckLineColor.OnGameOver -= EndGameResetTriggers;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ResetTrigger();
    }


    protected abstract void DetectSphere(SphereColor _sphere);

    public static int GetCountTriggerActive()
    {
        return countTriggerActive;
    }

    protected void EndGameResetTriggers()
    {
        countTriggerActive = 0;
        sphere = null;
        detectColor = SphereColor.sphereColorsEnum.empty;
    }

    public void ResetTrigger()
    {
        sphere = null;
        detectColor = SphereColor.sphereColorsEnum.empty;
        countTriggerActive--;
    }
}
