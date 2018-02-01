using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class UnitUtils{
    public static IEnumerable<IEnemyUnit> GetEnemyUnitsInRadius(Vector3 center, float range)
    {
        var unitsCollisionLayer = LayerMask.NameToLayer("EnemyUnit");
        var unitCollidersInRadius = Physics.OverlapSphere(center, range, unitsCollisionLayer);

        return unitCollidersInRadius.Select(collider => collider.GetComponent<IEnemyUnit>());
    }

    public static IEnemyUnit GetClosesEnemyUnitInRange(Vector3 center, float range)
    {
        var enemyUnitsInRange = UnitUtils.GetEnemyUnitsInRadius(center, range);

        return enemyUnitsInRange.Aggregate(
            (l, r) =>
                Vector3.Distance(l.GetPosition(), center) <
                Vector3.Distance(r.GetPosition(), center)
                    ? l
                    : r
        );
    }
}
