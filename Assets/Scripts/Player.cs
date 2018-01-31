using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour
{
    public GameResources[] Resources = 
    {
        new GameResources(GameResourcesType.Manpower, 0),
        new GameResources(GameResourcesType.Weapons, 0),
        new GameResources(GameResourcesType.TankMunition, 0) 
    };
}
