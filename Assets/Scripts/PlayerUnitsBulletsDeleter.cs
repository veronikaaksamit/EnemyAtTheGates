using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitsBulletsDeleter : MonoBehaviour
{

    public void DeleteAllPlayerUnits()
    {
        var playerInfantries = FindObjectsOfType<PlayerInfantry>();

        foreach (var infantry in playerInfantries)
        {
            Destroy(infantry);
        }
    }

    public void DeleteAllBullets()
    {
        var bullets = FindObjectsOfType<Bullet>();

        foreach (var bullet in bullets)
        {
            Destroy(bullet);
        }

    }

}
