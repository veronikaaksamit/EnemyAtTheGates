using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class UnitUtils{
    public static IEnumerable<IEnemyUnit> GetEnemyUnitsInRadius(Vector3 center, float range)
    {
        var unitsCollisionLayer = LayerMask.NameToLayer("EnemyUnit");
        int layerMask = 1 << unitsCollisionLayer;
        var unitCollidersInRadius = Physics.OverlapSphere(center, range, layerMask);

        return unitCollidersInRadius.Select(collider => collider.GetComponent<IEnemyUnit>());
    }

    public static IEnemyUnit GetClosesEnemyUnitInRange(Vector3 center, float range)
    {
        var enemyUnitsInRange = UnitUtils.GetEnemyUnitsInRadius(center, range);

        if (enemyUnitsInRange.Count() <= 0)
        {
            return null;
        }

        if (enemyUnitsInRange.Count() == 1)
        {
            return enemyUnitsInRange.First();
        }

        return enemyUnitsInRange.Aggregate(
            (l, r) =>
                Vector3.Distance(l.GetPosition(), center) <
                Vector3.Distance(r.GetPosition(), center)
                    ? l
                    : r
        );
    }
}
