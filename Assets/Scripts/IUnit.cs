using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitAffiliation
{
    Error = 0,
    Enemy,
    Player
}

public interface IUnit
{
    UnitAffiliation GetAffiliation();

    UnitType GetUnitType();

    int GetHealth();

    Vector3 GetPosition();

    void TakeDamage(int damage, IUnit damageDealer);

    GameResources GetCost();
}
