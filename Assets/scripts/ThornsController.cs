using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornsController : MonoBehaviour
{
    [SerializeField] private TriggerColorDetect[] line;
    [SerializeField] private GameObject thorns;

    private void OnEnable()
    {
        StartCoroutine("CheckLineCor");
        CheckTriggerColors.OnGameOver += ResetThorns;
    }
    private void OnDisable()
    {
        CheckTriggerColors.OnGameOver += ResetThorns;
    }


    IEnumerator CheckLineCor()
    {
        while (true)
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
    }

    private void ResetThorns()
    {
        thorns.SetActive(false);
    }
   


}
