using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyUnit
{

    void TakeDamage(int damage, IPlayerUnit damageDealer);

    int GetHealth();

    Vector3 GetPosition();

}
