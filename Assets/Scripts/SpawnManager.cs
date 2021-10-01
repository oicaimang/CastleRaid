using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject playerBluePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerup"))
        {
            Destroy(other.gameObject);
            spawnPrefab();
            
        }
    }
    void spawnPrefab()
    {
        for (int i = 0; i < 5; i++)
        {
           
            Vector3 newpositionPrefab = new Vector3(playerBluePrefab.transform.position.x, playerBluePrefab.transform.position.y, playerBluePrefab.transform.position.z);
            Instantiate(playerBluePrefab, newpositionPrefab, playerBluePrefab.transform.rotation);
        }
    }
}
