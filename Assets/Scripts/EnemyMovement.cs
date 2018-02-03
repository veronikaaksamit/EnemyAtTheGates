using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyMovement : MonoBehaviour
    {
        private Transform cityHall;
        private UnityEngine.AI.NavMeshAgent nav;

        void Start ()
        {
            cityHall = GameObject.FindGameObjectWithTag("CityHall").transform;
            nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        }
	
        void Update () {
            if (!nav.isActiveAndEnabled)
            {
                nav.enabled = true;
            }
            nav.SetDestination(cityHall.position);
        }
    }
}
