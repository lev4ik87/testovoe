using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySphere : MonoBehaviour
{
    [SerializeField] GameObject partcilePrefab;
    private GameObject particle;
    private void OnEnable()
    {
        CheckLineColor.OnGameOver += ResetSphere;
    }
    private void OnDisable()
    {
        CheckLineColor.OnGameOver -= ResetSphere;
    }


    public void DestoySphere()
    {
      particle = Instantiate(partcilePrefab, transform.position, Quaternion.identity);
      particle.transform.SetParent(transform.parent, false);
      particle.transform.position = transform.position;

      Destroy(gameObject);
    }

    private void ResetSphere()
    {
        Destroy(gameObject);
    }
}
