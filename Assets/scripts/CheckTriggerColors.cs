using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckTriggerColors : MonoBehaviour
{
    [SerializeField] TriggerColorDetect[] gorizontLine_1;
    [SerializeField] TriggerColorDetect[] gorizontLine_2;
    [SerializeField] TriggerColorDetect[] gorizontLine_3;

    [SerializeField] TriggerColorDetect[] verticalLine_1;
    [SerializeField] TriggerColorDetect[] verticalLine_2;
    [SerializeField] TriggerColorDetect[] verticalLine_3;

    [SerializeField] TriggerColorDetect[] diagonalLine_1;
    [SerializeField] TriggerColorDetect[] diagonalLine_2;


    private TriggerColorDetect[] triggers;

    public static event Action OnGameOver;

    private void OnEnable()
    {
        StartCoroutine("checkLineCor");
    } 

    IEnumerator checkLineCor()
    {    
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            CheckLine(gorizontLine_1);
            CheckLine(gorizontLine_2);
            CheckLine(gorizontLine_3);

            CheckLine(verticalLine_1);
            CheckLine(verticalLine_2);
            CheckLine(verticalLine_3);

            CheckLine(diagonalLine_1);
            CheckLine(diagonalLine_2);

            yield return new WaitForSeconds(0.5f);

            if (TriggerColorDetect.GetCountTriggerActive() == 9)
            {
                OnGameOver?.Invoke();
            }
        }
    }

  

    private void CheckLine(TriggerColorDetect[] line)
    {
        if ((line[0].detectColor != SphereColor.sphereColorsEnum.empty && line[0].detectColor == line[1].detectColor) 
            && (line[1].detectColor != SphereColor.sphereColorsEnum.empty && line[1].detectColor == line[2].detectColor))
        {
            foreach (var item in line)
            {
                if (item.sphere != null)
                {
                item.sphere.GetComponent<SphereScore>().AddScore();
                item.sphere.GetComponent<DestroySphere>().DestoySphere();
                }
              
            }
        }
    }



}
