using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyUnit
{

    void TakeDamage(float damage, IPlayerUnit damageDealer);

    void TakeDamageUnmodified(float damage);

    float GetHealth();

    Vector3 GetPosition();

}
