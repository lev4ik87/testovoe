using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColorDetect : MonoBehaviour
{
    public SphereColor.sphereColorsEnum detectColor;
    [HideInInspector]  public GameObject sphere;
    private static int countTriggerActive;

    private Transform _transform;
    private Collider2D[] colliderSphere;

    [SerializeField] private GameObject nextTrigger;
    [SerializeField] bool downTrigger; 

    private void OnEnable()
    {
        CheckTriggerColors.OnGameOver += ResetTrigger;
        _transform = transform;
        StartCoroutine("OverlapCor");
       
    }
    private void OnDisable()
    {
        CheckTriggerColors.OnGameOver -= ResetTrigger;
    }


    IEnumerator OverlapCor()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            OverlapTic();
        }
      
    }

    public void OverlapTic()
    {
        colliderSphere = Physics2D.OverlapCircleAll(_transform.position, 1f);

        if (colliderSphere.Length > 0)
        {    
            if (sphere == null)
            {
                colliderSphere[0].TryGetComponent<SphereColor>(out SphereColor _sphere);
                sphere = _sphere.gameObject;
                detectColor = _sphere.color;
                countTriggerActive++; 
            }

            if (nextTrigger != null)
            {
                nextTrigger.SetActive(true);
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

            if (!downTrigger)
            {
                gameObject.SetActive(false);
            }

        }
    }

    public static int GetCountTriggerActive()
    {
        return countTriggerActive;
    }

    private void ResetTrigger()
    {
        countTriggerActive = 0;
        sphere = null;
        detectColor = SphereColor.sphereColorsEnum.empty;
    }
}
