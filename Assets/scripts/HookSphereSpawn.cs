using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HookSphereSpawn : MonoBehaviour
{
    [SerializeField] private Transform hook;
    [SerializeField] private Transform dynamicCanvas;
    [SerializeField] private GameObject[] spherePrefabs;

    private GameObject sphere;

    public event Action<GameObject> OnGetSphere;

    private void Start()
    {
        SphereSpawn();
    }


    private void SphereSpawn()
    {
     sphere = Instantiate(spherePrefabs[UnityEngine.Random.Range(0, spherePrefabs.Length)], Vector2.zero, Quaternion.identity);
     sphere.transform.SetParent(hook, false);
     sphere.transform.position = hook.position;
     OnGetSphere?.Invoke(sphere);
    }

    IEnumerator SphereSpawnCor()
    {
        yield return new WaitForSeconds(1);

        SphereSpawn();
    } 
}
