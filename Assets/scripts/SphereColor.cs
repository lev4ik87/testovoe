using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColor : MonoBehaviour
{
    IResetTrigger trigger;
    public enum sphereColorsEnum {green, blue, red , empty };
    [SerializeField] public sphereColorsEnum color;

    private void OnDisable()
    {
        if (trigger != null)    
        trigger.ResetTrigger();
    }

   public void GetTrigger(IResetTrigger _trigger)
    {
        trigger = _trigger;
    }
}
