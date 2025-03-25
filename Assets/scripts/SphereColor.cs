using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColor : MonoBehaviour
{
    public enum sphereColorsEnum {green, blue, red , empty };
    [SerializeField] public sphereColorsEnum color;
}
