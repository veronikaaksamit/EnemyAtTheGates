using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum GameResourcesType
{
    Error = 0,
    Manpower,
    Weapons,
    TankMunition
}

[System.Serializable]
public class GameResources
{
    public GameResources(GameResourcesType type, int count)
    {
        Type = type;
        Count = count;
    }

    [SerializeField] public GameResourcesType Type;
    [SerializeField] public int Count;
}
