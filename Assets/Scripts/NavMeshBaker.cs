using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBaker : MonoBehaviour
{
    public void BakeNavMesh()
    {
        foreach (NavMeshSurface surface in GetComponents<NavMeshSurface>())
        {
            surface.BuildNavMesh();
        }
    }
}
