using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager1 : MonoBehaviour
{
    public GameObject[] applePrefabs;
    private float lowerXLimit = 3;
    private float upperXLimit = 12.5f;
    private float lowerSpawnTime = 1;
    private float upperSpawnTime = 3;
    private float increaseInterval = 10;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnApples", 1);
        InvokeRepeating("DecreaseSpawnTime", increaseInterval, increaseInterval);
    }

    void SpawnApples()
    {
        int appleIndex = Random.Range(0, applePrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(lowerXLimit, upperXLimit), 17, -1.5f);

        Instantiate(applePrefabs[appleIndex], spawnPos, applePrefabs[appleIndex].transform.rotation);

        float spawnTime = Random.Range(lowerSpawnTime, upperSpawnTime);
        Invoke("SpawnApples", spawnTime);
    }

    void DecreaseSpawnTime()
    {
        if (lowerSpawnTime != 0.2f)
            lowerSpawnTime -= 0.2f;
        if (upperSpawnTime != 1.0f)
            upperSpawnTime -= 0.2f;
    }

}
