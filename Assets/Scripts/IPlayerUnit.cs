using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IPlayerUnit
{
    UnitType GetType();

    void TakeDamage(int damage, IEnemyUnit damageDealer);

    int GetExperienceLevel();

    GameResources GetCost();

    //TODO: zvyseni efektivity pomoci sberu enemy zbrane
}
