using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HookSphereSpawn : MonoBehaviour
{
    [SerializeField] private Transform hook;
    [SerializeField] private Transform dynamicCanvas;
    [SerializeField] private GameObject[] spherePrefabs;

    [SerializeField] HookSphereDrop hookSphereDrop;

    private GameObject sphere;

    private void OnEnable()
    {
        hookSphereDrop.OnDropSphere += SphereSpawn;
        SphereSpawn();
    }
    private void OnDisable()
    {
        hookSphereDrop.OnDropSphere -= SphereSpawn;
    }


    private void SphereSpawn()
    {
     sphere = Instantiate(spherePrefabs[UnityEngine.Random.Range(0, spherePrefabs.Length)], Vector2.zero, Quaternion.identity);
     sphere.transform.SetParent(hook, false);
     sphere.transform.position = hook.position;
     hookSphereDrop.GetSphere(sphere);
    }

}
