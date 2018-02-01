using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class Infantryman : MonoBehaviour, IUnit
{
    [SerializeField] private UnitAffiliation m_affiliation;
    [SerializeField] private int m_health = 1;
    [SerializeField] private float m_reloadTimeInS = 1.0f;
    [SerializeField] private float m_damagePerShot = 1.0f;
    [SerializeField] private float m_range = 1.0f;
    [SerializeField] private int m_experience = 0;
    [SerializeField] private GameResources m_cost = new GameResources(GameResourcesType.Manpower, 10);

    void Update()
    {
        var closestOpposingUnit = GetClosestOpposingUnitInRange();

        TryShootAt(closestOpposingUnit);
    }

    public UnitAffiliation GetAffiliation()
    {
        return m_affiliation;
    }

    public UnitType GetUnitType()
    {
        return UnitType.Infatryman;
    }

    public int GetHealth()
    {
        return m_health;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void TakeDamage(int damage, IUnit damageDealer)
    {
        m_health -= damage;
    }

    public GameResources GetCost()
    {
        return m_cost;
    }

    private IEnumerable<IUnit> GetOpposingUnitsInRange()
    {
        switch (m_affiliation)
        {
            case UnitAffiliation.Enemy:
                return UnitUtils.GetPlayerUnitsInRadius(transform.position, m_range);

            case UnitAffiliation.Player:
                return UnitUtils.GetEnemyUnitsInRadius(transform.position, m_range);

            case UnitAffiliation.Error:
                throw new InvalidOperationException(gameObject.name + ": unit's affiliation was not set.");

            default:
                throw new InvalidOperationException(gameObject.name + ": unit's affiliation is invalid");
        }
    }

    private IUnit GetClosestOpposingUnitInRange()
    {
        var opposingUnitsInRange = GetOpposingUnitsInRange();

        return opposingUnitsInRange.Aggregate(
            (l, r) =>
                Vector3.Distance(l.GetPosition(), GetPosition()) <
                Vector3.Distance(r.GetPosition(), GetPosition())
                    ? l
                    : r
        );
    }

    private void TryShootAt(IUnit target)
    {
        
    }
}
