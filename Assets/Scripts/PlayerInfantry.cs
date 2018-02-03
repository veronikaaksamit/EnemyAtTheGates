using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

//TODO: experience bonuses

[System.Serializable]
public class PlayerInfantry : MonoBehaviour, IPlayerUnit
{
    [SerializeField] private Bullet m_bulletToFire;
    [SerializeField] private float m_velocityToFireWith = 1.0f;
    [SerializeField] private float m_reloadTimeInS = 1.0f;
    [SerializeField] private float m_damagePerShot = 10.0f;
    [SerializeField] private float m_range = 1.0f;
    [SerializeField] private int m_experience = 0;
    [SerializeField] private float m_accuracy = 0.9f;

    private float m_timeSinceLastShotInS;

    void Update()
    {
        var closestOpposingUnit = UnitUtils.GetClosesEnemyUnitInRange(transform.position, m_range);

        if (closestOpposingUnit != null)
        {
            TryShootAt(closestOpposingUnit);
        }
    }

    public UnitType GetUnitType()
    {
        return UnitType.Infatryman;
    }

    private void TryShootAt(IEnemyUnit target)
    {
        if (Math.Abs(Time.time - m_timeSinceLastShotInS) < m_reloadTimeInS)
        {
            return;
        }

        //bool hits = UnityEngine.Random.Range(0.0f, 1.0f) < m_accuracy;

        //if (hits)
        //{
        //    target.TakeDamage(m_damagePerShot, this);

        //    if (target.GetHealth() <= 0)
        //    {
        //        ++m_experience;
        //    }
        //}

        Bullet firedBullet = Instantiate(m_bulletToFire);
        firedBullet.damage = m_damagePerShot;
        firedBullet.firedFrom = this;
        firedBullet.transform.position = transform.position;
        firedBullet.transform.LookAt(target.GetPosition());
        firedBullet.GetComponent<Rigidbody>().velocity =
            firedBullet.transform.forward * m_velocityToFireWith;
        Physics.IgnoreCollision(firedBullet.GetComponent<Collider>(), GetComponent<Collider>());

        m_timeSinceLastShotInS = Time.time;
    }
}
