using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerUnit
{
    UnitType GetUnitType();

    int GetHealth();

    Vector3 GetPosition();

    void SetPosition(Vector3 newPosition);
}
