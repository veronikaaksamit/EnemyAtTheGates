using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum BlockadeType
{
    Error = 0,
    Roadblock,
    AntiTankObstacle,
    Mines,
    BarbedWire
}

/*
 * We need type only for UI purposes (probably),
 * other stuff should be handled in implementating monobehaviour classes
 */
public interface IBlockade
{
    BlockadeType GetType();
}
