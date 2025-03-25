using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColorDetect_DownTrigger : SphereColorDetect
{
    [SerializeField] private GameObject midTrigger;
    [SerializeField] private GameObject upTrigger;

    public override void ColorDetect()
    {     
        colliderSphere = Physics2D.OverlapCircleAll(_transform.position, 0.1f);

        if (colliderSphere.Length > 0)
        {
            if (detectColor == SphereColor.sphereColorsEnum.empty)
            {
                colliderSphere[0].TryGetComponent<SphereColor>(out SphereColor _sphere);
                sphere = _sphere.gameObject;
                detectColor = _sphere.color;
                countTriggerActive++;    
                midTrigger.SetActive(true);
            }

           
        }
        else
        {
            if (detectColor != SphereColor.sphereColorsEnum.empty)
            {
                sphere = null;
                detectColor = SphereColor.sphereColorsEnum.empty;
                countTriggerActive--;
                Invoke("DisableEmptyTriggers", 1);
            }
        }
    } 
    
    private void DisableEmptyTriggers()
    {
        if (midTrigger.GetComponent<SphereColorDetect>().detectColor == SphereColor.sphereColorsEnum.empty)
            upTrigger.SetActive(false);

        if (detectColor == SphereColor.sphereColorsEnum.empty)
            midTrigger.SetActive(false);
    }
}
