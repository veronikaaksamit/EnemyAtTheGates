﻿using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider))]
    public class LoseCondition : MonoBehaviour
    {
        public UnityEvent GameLost;

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<IEnemyUnit>() == null)
            {
                return;
            }

            if (GameLost != null)
            {
                GameLost.Invoke();
            }
        }
    }
}
