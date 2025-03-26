using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColorDetect_UpTrigger : SphereColorDetect
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<SphereColor>(out SphereColor _sphere))
        {
            DetectSphere(_sphere);
        }
    }


    protected override void DetectSphere(SphereColor _sphere)
    {
        if (detectColor == SphereColor.sphereColorsEnum.empty)
        {
            sphere = _sphere.gameObject;
            detectColor = _sphere.color;
            countTriggerActive++;    
        }
    }

   
}
