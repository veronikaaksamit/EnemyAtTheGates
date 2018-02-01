using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class UnitUtils{
    public static IEnumerable<IUnit> GetUnitsInRadius(Vector3 center, float radius)
    {
        var unitsCollisionLayer = LayerMask.NameToLayer("Unit");
        var unitCollidersInRadius = Physics.OverlapSphere(center, radius, unitsCollisionLayer);

        return unitCollidersInRadius.Select(collider => collider.GetComponent<IUnit>());
    }

    public static IEnumerable<IUnit> GetEnemyUnitsInRadius(Vector3 center, float radius)
    {
        return GetUnitsInRadius(center, radius).Where(unit => unit.GetAffiliation() == UnitAffiliation.Enemy);
    }

    public static IEnumerable<IUnit> GetPlayerUnitsInRadius(Vector3 center, float radius)
    {
        return GetUnitsInRadius(center, radius).Where(unit => unit.GetAffiliation() == UnitAffiliation.Player);
    }
}
