using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuAnimSphereSpawn : MonoBehaviour
{
    [SerializeField]private GameObject spherePrefab;
    [SerializeField]private Transform[] spawnPointsUp;
    [SerializeField]private Transform[] spawnPointsDown;

    [SerializeField] private Transform menuDynamicCanvas;

    [SerializeField] private Color green;
    [SerializeField] private Color blue;
    [SerializeField] private Color red;

  
    private GameObject sphere;
 
   
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
                SpawnSphere();

                sphere.transform.position = spawnPointsUp[Random.Range(0, spawnPointsUp.Length)].position;
            }
            else
            {             
                SpawnSphere();

                sphere.transform.position = spawnPointsDown[Random.Range(0, spawnPointsDown.Length)].position;
                sphere.GetComponent<Rigidbody2D>().gravityScale *= -1;
            } 
        }
    }

    private void SpawnSphere()
    {
        sphere = Instantiate(spherePrefab, Vector2.zero, Quaternion.identity);
        sphere.transform.SetParent(menuDynamicCanvas, false);
        sphere.transform.localScale = Vector3.one * Random.Range(1.2f, 2.7f);

        switch (Random.Range(0,3))
        {
            case 0:
                sphere.GetComponent<Image>().color = green;
                break;

            case 1:
                sphere.GetComponent<Image>().color = blue;
                break;

            case 2:
                sphere.GetComponent<Image>().color = red;
                break;
        }

       
    }
 }
