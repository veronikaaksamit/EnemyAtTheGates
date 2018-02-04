using System.Linq;
using UnityEditorInternal;
using UnityEngine;

namespace Assets.Scripts
{
    public class BombarderMovement : MonoBehaviour
    {
        private GameObject target;
        private GameObject finishPoint;
        private bool toFinish;
        private bool isFlying;
        private UnityEngine.AI.NavMeshAgent nav;

        public void Fly(GameObject target)
        {
            this.target = target;
            float closestDistance = float.MaxValue;
            GameObject closestSpawnPoint = null;
            foreach (GameObject spawnpoint in GameObject.FindGameObjectsWithTag("AircraftSpawnPoint"))
            {
                float distance = Vector3.Distance(spawnpoint.transform.position, target.transform.position);
                if (distance < closestDistance)
                {
                    closestSpawnPoint = spawnpoint;
                    closestDistance = distance;
                }
            }
            closestSpawnPoint = GameObject.Find("AircraftSpawnPoint3");
            transform.position = closestSpawnPoint.transform.position;
            transform.rotation = closestSpawnPoint.transform.rotation;
            gameObject.transform.Rotate(closestSpawnPoint.transform.rotation.x, closestSpawnPoint.transform.rotation.y, closestSpawnPoint.transform.rotation.z);
            switch (closestSpawnPoint.name)
            {
                case "AircraftSpawnPoint1":
                    finishPoint = GameObject.Find("AircraftSpawnPoint3");
                    break;
                case "AircraftSpawnPoint2":
                    finishPoint = GameObject.Find("AircraftSpawnPoint4");
                    break;
                case "AircraftSpawnPoint3":
                    finishPoint = GameObject.Find("AircraftSpawnPoint1");
                    break;
                case "AircraftSpawnPoint4":
                    finishPoint = GameObject.Find("AircraftSpawnPoint2");
                    break;
                default:
                    finishPoint = GameObject.Find("AircraftSpawnPoint1");
                    break;
            }
            isFlying = true;
        }

        void Start ()
        {
            nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        }

        void Update()
        {
            if (!isFlying)
            {
                return;
            }
            if (!nav.isActiveAndEnabled)
            {
                nav.enabled = true;
            }
            if (toFinish)
            {
                nav.SetDestination(finishPoint.transform.position);
            }
            else if (target != null && !target.Equals(null))
            {
                nav.SetDestination(target.transform.position);
            }
            else
            {
                toFinish = true;
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (target != null && !target.Equals(null) && other.gameObject.Equals(target))
            {
                IEnemyUnit enemy = other.gameObject.GetComponents<Component>().OfType<IEnemyUnit>().First();
                enemy.TakeDamageUnmodified(enemy.GetHealth() + 10);
                toFinish = true;
            }
            else if (toFinish && other.gameObject.Equals(finishPoint))
            {
                isFlying = false;
                Destroy(gameObject);
            }
        }
    }
    
}
