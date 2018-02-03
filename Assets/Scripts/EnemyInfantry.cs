using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfantry : MonoBehaviour, IEnemyUnit {

    [SerializeField]
    private float m_health = 10.0f;


    void Update()
    {
        if (m_health <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamageUnmodified(float damage)
    {
        m_health -= damage;
    }

    public float GetHealth()
    {
        return m_health;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void TakeDamage(float damage, IPlayerUnit damageDealer)
    {
        m_health -= damage;
    }
}
