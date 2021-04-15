using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public GameObject EnemyPrefab;
    static int countEnemies;

    // Start is called before the first frame update
    void Start()
    {
        countEnemies = 0;
        for (int i = 0; i < 3; i++)
        {
            Vector3 position = EnemyPrefab.transform.position + new Vector3(i * 1.3f, 0);
            Instantiate(EnemyPrefab, position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -10)
        {
            Destroy(this.gameObject);
        }
    }
}
