﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class WinCondition : MonoBehaviour
{
    public UnityEvent GameWon;

    private List<EnemyManager> _mEnemyManagers;

    void Start()
    {
        _mEnemyManagers = FindObjectsOfType<EnemyManager>().ToList();
    }

    void Update()
    {
        if (!AllUnitsHaveBeenSpawned())
        {
            return;
        }

        if (!AreAllEnemyUnitsDead())
        {
            return;
        }

        if (GameWon != null)
        {
            GameWon.Invoke();
        }
    }

    bool AllUnitsHaveBeenSpawned()
    {
        foreach(var enemyManager in _mEnemyManagers)
        {
            if (enemyManager.NumberOfEnemies > 0)
            {
                return false;
            }
        }

        return true;
    }

    bool AreAllEnemyUnitsDead()
    {
        var enemyInfantry = FindObjectsOfType<EnemyInfantry>();
        var enemyTanks = FindObjectsOfType<EnemyTank>();

        return enemyInfantry.Length == 0 &&
               enemyTanks.Length == 0;
    }
}
