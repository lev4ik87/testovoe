using System.Collections;
using UnityEngine;

public class ThornsController : MonoBehaviour
{
    [SerializeField] private SphereColorDetect[] line;
    [SerializeField] private GameObject thorns;

    private int timerValue;

    private void OnEnable()
    {  
        CheckLineColor.OnGameOver += ResetThorns;
    }
    private void OnDisable()
    {
        CheckLineColor.OnGameOver += ResetThorns;
    }


    IEnumerator CheckLineCor()
    {
        yield return new WaitForSeconds(1);
        if (line[0].sphere != null && line[1].sphere != null && line[2].sphere != null)
        {
            if (line[0].detectColor != line[1].detectColor || line[1].detectColor != line[2].detectColor)
            {      
                thorns.SetActive(true);
            }
        }
        else
        {
            thorns.SetActive(false);
        }
    }

    public void CheckLine()
    { 
        StartCoroutine("CheckLineCor");
    }

    private void ResetThorns()
    {
        thorns.SetActive(false);
    }



}
