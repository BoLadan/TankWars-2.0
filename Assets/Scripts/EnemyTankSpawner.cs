using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankSpawner : MonoBehaviour
{
    public enum SpawnState { spawning, waiting, counting }; 
    [System.Serializable]

    public class Wave
    {
        public string name;
        public Transform enemyTank;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnaPoint;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;
    private SpawnState state = SpawnState.counting;

    private float searchCountdown = 1f;

    void Start()
    {
        waveCountdown = timeBetweenWaves;

        if (spawnaPoint.Length == 0)
        {
            Debug.LogError("No spawnpoints refrenced.");
        }
    }

    void Update()
    {

        if (state == SpawnState.waiting)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");
        state = SpawnState.counting;
        waveCountdown = timeBetweenWaves;
        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("ALL waves Complete Looping...");
        } else
        {
            nextWave++;
        }
        
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnWave (Wave _wave)
    {
        Debug.Log("Spawning Wave" + _wave.name);
        state = SpawnState.spawning;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemyTank);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.waiting;

        yield break;
    }

    void SpawnEnemy(Transform _enemyTank)
    {
        Debug.Log("Spawning Enemy: " + _enemyTank.name);

        
        Transform _sp = spawnaPoint[Random.Range(0, spawnaPoint.Length)];
        Instantiate(_enemyTank, _sp.position, _sp.rotation);
    }
}
