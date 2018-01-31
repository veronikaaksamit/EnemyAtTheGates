using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject InfantrymanPrefab;
    public GameObject SniperPrefab;
    public GameObject MachineGunNestPrefab;
    public GameObject TankPrefab;

    public GameResources[] Resources = 
    {
        new GameResources(GameResourcesType.Manpower, 0),
        new GameResources(GameResourcesType.Weapons, 0),
        new GameResources(GameResourcesType.TankMunition, 0) 
    };

    public IBlockade[] AvailableBlockades;

    //TODO: bombarder??
}
