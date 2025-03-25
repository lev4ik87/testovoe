using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookSphereSpawn : MonoBehaviour
{
    [SerializeField] private Transform hook;
    [SerializeField] private Transform dynamicCanvas;
    [SerializeField] private GameObject[] spherePrefabs;

    private GameObject sphere;

    private void OnEnable()
    {
        InputController.OnOneTap += DropSphere;
        SphereSpawn();
    }
    private void OnDisable()
    {
        InputController.OnOneTap -= DropSphere;
    }


    private void SphereSpawn()
    {
     sphere = Instantiate(spherePrefabs[Random.Range(0, spherePrefabs.Length)], Vector2.zero, Quaternion.identity);
     sphere.transform.SetParent(hook, false);
     sphere.transform.position = hook.position;
    }

    IEnumerator SphereSpawnCor()
    {
        yield return new WaitForSeconds(1);

        SphereSpawn();
    }

    private void DropSphere()
    {
        if (sphere != null)
        {
            sphere.transform.SetParent(dynamicCanvas, false);
            sphere.transform.position = hook.position;
            sphere.GetComponent<Rigidbody2D>().simulated = true;
            sphere = null;
            StartCoroutine("SphereSpawnCor");
        }
    }
}
