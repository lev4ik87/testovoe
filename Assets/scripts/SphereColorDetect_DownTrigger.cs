using System.Collections;
using UnityEngine;

public class SphereColorDetect_DownTrigger : SphereColorDetect
{
    [SerializeField] private SphereColorDetect midTrigger;
    [SerializeField] private SphereColorDetect upTrigger;


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
            yield return new WaitForSeconds(2);
            DisableEmptyTrigger();
        }
    }


    protected override void DetectSphere(SphereColor _sphere)
    {
        sphere = _sphere.gameObject;
        detectColor = _sphere.color;
        countTriggerActive++;
        midTrigger.GetComponent<Collider2D>().enabled = true;   
    }

    private void DisableEmptyTrigger()
    {
        if (midTrigger.detectColor == SphereColor.sphereColorsEnum.empty 
            && upTrigger.detectColor == SphereColor.sphereColorsEnum.empty)

            upTrigger.GetComponent<Collider2D>().enabled = false;

        if (detectColor == SphereColor.sphereColorsEnum.empty 
            && midTrigger.detectColor == SphereColor.sphereColorsEnum.empty
            && upTrigger.detectColor == SphereColor.sphereColorsEnum.empty)

            midTrigger.GetComponent<Collider2D>().enabled = false;
    }

}
