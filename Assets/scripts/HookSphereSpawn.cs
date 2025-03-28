using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

public class HookSphereSpawn : MonoBehaviour
{
    [SerializeField] private Transform hook;
    [SerializeField] private Transform dynamicCanvas;
    [SerializeField] private GameObject[] spherePrefabs;

    [Inject] private HookSphereDrop hookSphereDrop;
    [Inject] private DiContainer container;
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
     sphere = container.InstantiatePrefab(spherePrefabs[UnityEngine.Random.Range(0, spherePrefabs.Length)], Vector2.zero, Quaternion.identity, null);
     sphere.transform.SetParent(hook, false);
     sphere.transform.position = hook.position;
     hookSphereDrop.GetSphere(sphere);
    }

}
