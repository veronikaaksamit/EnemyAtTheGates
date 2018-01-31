using UnityEngine;

interface IEnemyUnit
{
    UnitType GetType();
    void TakeDamage(int damage, IPlayerUnit damageDealer);

}
