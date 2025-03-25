using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColorDetect_DownTrigger : SphereColorDetect
{
    [SerializeField] private GameObject midTrigger;
    [SerializeField] private GameObject upTrigger;


    private void OnEnable()
    {
        StartCoroutine("DisableTriggersCor");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.TryGetComponent<SphereColor>(out SphereColor _sphere))
        { 
            DetectSphere(_sphere);
        } 
    }

    IEnumerator DisableTriggersCor()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            DisableEmptyTrigger();
        }
    }


    protected override void DetectSphere(SphereColor _sphere)
    {
        if (detectColor == SphereColor.sphereColorsEnum.empty)
        {      
            sphere = _sphere.gameObject;
            sphere.GetComponent<SphereColor>().GetTrigger(this);
            detectColor = _sphere.color;
            countTriggerActive++;
            midTrigger.SetActive(true);
        }
    }

    private void DisableEmptyTrigger()
    {
        if (midTrigger.GetComponent<SphereColorDetect>().detectColor == SphereColor.sphereColorsEnum.empty)
            upTrigger.SetActive(false);

        if (detectColor == SphereColor.sphereColorsEnum.empty)
            midTrigger.SetActive(false);
    }
 
}
