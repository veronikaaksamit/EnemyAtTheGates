using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.AI;

public class BlockadeDestroy : MonoBehaviour
{
    private List<EnemyMovement> destroyersMovement = new List<EnemyMovement>();

    void Start()
    { }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            EnemyDestroyBlockade component = other.gameObject.GetComponent<EnemyDestroyBlockade>();
            if (component != null && component.BlockadeTag == tag)
            {
                EnemyMovement movement = other.gameObject.GetComponent<EnemyMovement>();
                movement.movementEnabled = false;
                if (destroyersMovement.Count == 0)
                {
                    Invoke("DestroyBlockade", component.TimeToDestroy);
                }
                destroyersMovement.Add(movement);
            }
        }
    }

    void DestroyBlockade()
    {
        foreach (EnemyMovement enemyMovement in destroyersMovement)
        {
            enemyMovement.movementEnabled = true;
        }
        destroyersMovement.Clear();
        Destroy(gameObject);
        GameObject.FindGameObjectWithTag("Navigation").GetComponent<NavMeshBaker>().BakeNavMesh();
    }
}
