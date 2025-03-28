using UnityEngine;

public class SphereColorDetect_MidTrigger : SphereColorDetect
{
    [SerializeField] private GameObject upTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<SphereColor>(out SphereColor _sphere))
        {
            DetectSphere(_sphere);
        }
    }

    protected override void DetectSphere(SphereColor _sphere)
    {
        sphere = _sphere.gameObject;
        detectColor = _sphere.color;
        countTriggerActive++;
        upTrigger.GetComponent<Collider2D>().enabled = true;
    }
}
