using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IPlayerUnit
{
    void TakeDamage(int damage, IEnemyUnit damageDealer);

    GameResources GetCost();
    //TODO: zvyseni efektivity pomoci sberu enemy zbrane
}
