using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour, IEnemyUnit
{
    [SerializeField]
    private float m_health = 50.0f;
    [SerializeField]
    private float m_fromInfantryDamageModifier = 0.5f;
    [SerializeField]
    private float m_fromSniperDamageModifier = 0.5f;


    void Update()
    {
        if(m_health <= 0.0f)
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
        if(damageDealer.GetUnitType() == UnitType.Infatryman )
        {
            damage *= m_fromInfantryDamageModifier;
        }
        else if(damageDealer.GetUnitType() == UnitType.Sniper)
        {
            damage *= m_fromSniperDamageModifier;
        }

        m_health -= damage;
    }
}
