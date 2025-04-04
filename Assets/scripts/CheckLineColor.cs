using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckLineColor : MonoBehaviour
{
    [SerializeField] SphereColorDetect[] gorizontLine_1;
    [SerializeField] SphereColorDetect[] gorizontLine_2;
    [SerializeField] SphereColorDetect[] gorizontLine_3;

    [SerializeField] SphereColorDetect[] verticalLine_1;
    [SerializeField] SphereColorDetect[] verticalLine_2;
    [SerializeField] SphereColorDetect[] verticalLine_3;

    [SerializeField] SphereColorDetect[] diagonalLine_1;
    [SerializeField] SphereColorDetect[] diagonalLine_2;
 
    public static event Action OnGameOver;

    private void OnEnable()
    {
        StartCoroutine("checkLineCor");
    } 

    IEnumerator checkLineCor()
    {    
        while (true)
        {

            CheckLine(gorizontLine_1);
            CheckLine(gorizontLine_2);
            CheckLine(gorizontLine_3);

            CheckLine(verticalLine_1);
            CheckLine(verticalLine_2);
            CheckLine(verticalLine_3);

            CheckLine(diagonalLine_1);
            CheckLine(diagonalLine_2);

            yield return new WaitForSeconds(1f);

            if (SphereColorDetect.GetCountTriggerActive() == 9)
            {
                OnGameOver?.Invoke();
            }
        }
    }

  

    private void CheckLine(SphereColorDetect[] line)
    {
        if (line[0].detectColor != SphereColor.sphereColorsEnum.empty && line[1].detectColor != SphereColor.sphereColorsEnum.empty 
            && line[2].detectColor != SphereColor.sphereColorsEnum.empty)
        {
            if (line[0].detectColor == line[1].detectColor && line[1].detectColor == line[2].detectColor)
            {
                foreach (var item in line)
                {
                    item.sphere.GetComponent<ScoreSphere>().AddScore();
                    item.sphere.GetComponent<DestroySphere>().DestoySphere();
                }
            }
        }
    }



}
