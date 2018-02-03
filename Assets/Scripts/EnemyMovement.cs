using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyMovement : MonoBehaviour
    {
        private Transform cityHall;
        private UnityEngine.AI.NavMeshAgent nav;
        public bool movementEnabled = true;

        void Start ()
        {
            cityHall = GameObject.FindGameObjectWithTag("CityHall").transform;
            nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        }

        void Update()
        {
            if (!nav.isActiveAndEnabled)
            {
                nav.enabled = true;
            }
            nav.isStopped = !movementEnabled;
            nav.SetDestination(cityHall.position);
        }
    }
    
}
