using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager2 : MonoBehaviour
{
    [SerializeField] GameObject[] itemPrefabs;
    [SerializeField] float minSpawnZ, maxSpawnZ;

    float lowerSpawnTime = 0.2f;
    float upperSpawnTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnItem", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnItem()
    {
        int itemIndex = Random.Range(0, itemPrefabs.Length);
        float spawnZ = Random.Range(minSpawnZ, maxSpawnZ);
        Vector3 spawnPos = new Vector3(0, 27, spawnZ);

        Instantiate(itemPrefabs[itemIndex], spawnPos, itemPrefabs[itemIndex].transform.rotation);

        float spawnTime = Random.Range(lowerSpawnTime, upperSpawnTime);
        Invoke("SpawnItem", spawnTime);
    }
}
