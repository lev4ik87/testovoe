using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookSphereDrop : MonoBehaviour
{
    [SerializeField] private Transform hook;
    [SerializeField] private Transform dynamicCanvas;
    [SerializeField] HookSphereSpawn hookSphereSpawn;
    private GameObject sphere;

    private void OnEnable()
    {
        InputController.OnOneTap += DropSphere;
        hookSphereSpawn.OnGetSphere += GetSphere;
    }
    private void OnDisable()
    {
        InputController.OnOneTap -= DropSphere;
        hookSphereSpawn.OnGetSphere -= GetSphere;
    }

    private void DropSphere()
    {
        if (sphere != null)
        {
            sphere.transform.SetParent(dynamicCanvas, false);
            sphere.transform.position = hook.position;
            sphere.GetComponent<Rigidbody2D>().simulated = true;
            sphere = null;
            hookSphereSpawn.StartCoroutine("SphereSpawnCor");
        }
    }

    private void GetSphere(GameObject _sphere)
    {
        sphere = _sphere;
    }
}
