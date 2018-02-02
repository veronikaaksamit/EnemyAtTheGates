using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject Enemy;
    public float SpawnTime = 12f;
    public int NumberOfEnemies = 4;
    public bool Rotate = true;
    public Transform[] SpawnPoints;


    void Start ()
    {
        if (NumberOfEnemies > 0)
        {
            InvokeRepeating("Spawn", SpawnTime, SpawnTime);
        }

    }


    void Spawn()
    {
        if (NumberOfEnemies > 0)
        {
            int spawnPointIndex = Random.Range(0, SpawnPoints.Length);

            Quaternion rotation;
            if (Rotate)
            {
                rotation = SpawnPoints[spawnPointIndex].rotation;
            }
            else
            {
                rotation = Enemy.transform.rotation;
            }
            Instantiate(Enemy, SpawnPoints[spawnPointIndex].position, rotation);
            NumberOfEnemies--;
            if (NumberOfEnemies == 0) CancelInvoke("Spawn");
        }
    }
    
}
