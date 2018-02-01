using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuilding
{
    bool IsOccupied();

    IPlayerUnit GetOccupyingUnit();

    void SetOccupyingUnit(IPlayerUnit playerUnit);

}
