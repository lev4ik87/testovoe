using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColorDetect_UpTrigger : SphereColorDetect
{
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
            }
        }
        else
        {
            if (detectColor != SphereColor.sphereColorsEnum.empty)
            {
                sphere = null;
                detectColor = SphereColor.sphereColorsEnum.empty;
                countTriggerActive--;    
            }
        }
    }
}
