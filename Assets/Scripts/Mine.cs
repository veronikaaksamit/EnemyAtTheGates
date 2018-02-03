using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float m_damage = 50.0f;

    void OnCollisionEnter(Collision collision)
    {
        var enemyUnit = collision.gameObject.GetComponent<IEnemyUnit>();

        if (enemyUnit == null)
            return;

        enemyUnit.TakeDamageUnmodified(m_damage);
    }

}
