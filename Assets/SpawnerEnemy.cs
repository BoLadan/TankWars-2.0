using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] Tank;
    int randomSpawnPoint, randomTank;
    public static bool spawnAllowed;

    // Start is called before the first frame update
    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnATank", 0f, 1f);
    }

    void SpawnATank()
    {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomTank = Random.Range(0, Tank.Length);
            Instantiate(Tank[randomTank], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
    }
}
