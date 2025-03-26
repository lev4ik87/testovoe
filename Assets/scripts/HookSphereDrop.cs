using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HookSphereDrop : MonoBehaviour
{
    [SerializeField] private Transform hook;
    [SerializeField] private Transform dynamicCanvas;
   
    private GameObject sphere;

    public event Action OnDropSphere;

    private void OnEnable()
    {
        InputController.OnOneTap += DropSphere;      
    }
    private void OnDisable()
    {
        InputController.OnOneTap -= DropSphere;   
    }

    private void DropSphere()
    {
        if (sphere != null)
        {
            sphere.transform.SetParent(dynamicCanvas, false);
            sphere.transform.position = hook.position;
            sphere.GetComponent<Rigidbody2D>().simulated = true;
            sphere = null;
            Invoke("SpawnSphere", 1);
        }
    }

    private void SpawnSphere()
    {
        OnDropSphere?.Invoke();
    }

    public void GetSphere(GameObject _sphere)
    {
        sphere = _sphere;
    }
}
