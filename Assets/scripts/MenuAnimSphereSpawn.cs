using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimSphereSpawn : MonoBehaviour
{
    [SerializeField]private GameObject[] spherePrefabs;
    [SerializeField]private Transform[] spawnPointsUp;
    [SerializeField]private Transform[] spawnPointsDown;

    [SerializeField] private Transform menuDynamicCanvas;

  
    private GameObject sphere;
 
    void Start()
    {
        Application.targetFrameRate = 60;
    }
    private void OnEnable()
    {
       
        StartCoroutine("SphereSpawnCor");
    }

    IEnumerator SphereSpawnCor()
    {
        while (true)
        {
        yield return new WaitForSeconds(0.4f);

            if (Random.Range(0, 2) == 0)
            {
                sphere = Instantiate(spherePrefabs[Random.Range(0, spherePrefabs.Length)], Vector2.zero, Quaternion.identity);
                sphere.transform.SetParent(menuDynamicCanvas, false);
                sphere.transform.position = spawnPointsUp[Random.Range(0, spawnPointsUp.Length)].position;
            }
            else
            {
                sphere = Instantiate(spherePrefabs[Random.Range(0, spherePrefabs.Length)], Vector2.zero, Quaternion.identity);
                sphere.GetComponent<Rigidbody2D>().gravityScale *= -1;
                sphere.transform.SetParent(menuDynamicCanvas, false);
                sphere.transform.position = spawnPointsDown[Random.Range(0, spawnPointsDown.Length)].position;
            } 
        }
    }

}
