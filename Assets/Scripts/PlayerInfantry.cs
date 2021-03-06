﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

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
    [SerializeField] private float m_shootsToDouble = 500f;

    private float m_timeSinceLastShotInS;
    private FocusTargetManager m_focusTargetManager;

    void Start()
    {
        m_focusTargetManager = FindObjectOfType<FocusTargetManager>();
    }

    void Update()
    {
        var focusTarget = m_focusTargetManager.FocusTarget;

        var closestOpposingUnit = UnitUtils.GetClosesEnemyUnitInRange(transform.position, m_range, focusTarget);

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
        firedBullet.damage = m_damagePerShot * (1 + m_experience / m_shootsToDouble);
        firedBullet.firedFrom = this;
        firedBullet.accuracy = m_accuracy;
        firedBullet.transform.position = transform.position;
        firedBullet.transform.LookAt(target.GetPosition());
        firedBullet.GetComponent<Rigidbody>().velocity =
            firedBullet.transform.forward * m_velocityToFireWith;
        Physics.IgnoreCollision(firedBullet.GetComponent<Collider>(), GetComponent<Collider>());

        m_timeSinceLastShotInS = Time.time;
        m_experience++;
    }
}
