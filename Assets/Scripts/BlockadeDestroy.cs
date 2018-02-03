using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.AI;

public class BlockadeDestroy : MonoBehaviour
{
    private List<GameObject> destroyers = new List<GameObject>();
    private const float START_PERCENTAGE = 100f;
    private float remainsPercentage = START_PERCENTAGE;

    void Start()
    { }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            foreach (EnemyDestroyBlockade component in other.gameObject.GetComponents<EnemyDestroyBlockade>())
            {
                if (component != null && component.BlockadeTag == tag)
                {
                    GameObject enemy = other.gameObject;
                    enemy.GetComponent<EnemyMovement>().movementEnabled = false;
                    destroyers.Add(enemy);
                    break;
                }
            }
        }
    }

    void DestroyBlockade()
    {
        foreach (GameObject enemy in destroyers)
        {
            if (enemy != null && !enemy.Equals(null))
            {
                enemy.GetComponent<EnemyMovement>().movementEnabled = true;
            }
        }
        destroyers.Clear();
        Destroy(gameObject);
        GameObject.FindGameObjectWithTag("Navigation").GetComponent<NavMeshBaker>().BakeNavMesh();
    }

    void Update()
    {
        foreach (GameObject enemy in destroyers)
        {
            if (enemy == null || enemy.Equals(null))
            {
                destroyers.Remove(enemy);
            }
            else
            {
                foreach (EnemyDestroyBlockade attack in enemy.GetComponents<EnemyDestroyBlockade>())
                {
                    if (attack.BlockadeTag == tag)
                    {
                        if (attack.TimeToDestroy <= 0)
                        {
                            remainsPercentage = 0;
                        }
                        else
                        {
                            remainsPercentage -= START_PERCENTAGE / attack.TimeToDestroy * Time.deltaTime;
                        }
                        break;
                    }
                }
            }
        }
        if (remainsPercentage <= 0)
        {
            DestroyBlockade();
        }
    }
}
