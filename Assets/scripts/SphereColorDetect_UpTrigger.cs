using UnityEngine;

public class SphereColorDetect_UpTrigger : SphereColorDetect
{
    [SerializeField] ThornsController thornsController;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<SphereColor>(out SphereColor _sphere))
        {
            DetectSphere(_sphere);
        }

        thornsController.CheckLine();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        ResetTrigger();

        if (thornsController.isActiveAndEnabled)
            thornsController.CheckLine();
    }


    protected override void DetectSphere(SphereColor _sphere)
    {
        sphere = _sphere.gameObject;
        detectColor = _sphere.color;
        countTriggerActive++;
        Debug.Log(countTriggerActive + " " + gameObject.name);
    }

}
