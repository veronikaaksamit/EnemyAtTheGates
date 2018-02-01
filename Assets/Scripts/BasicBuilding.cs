using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBuilding : MonoBehaviour, IBuilding
{
    private IPlayerUnit m_OccupyingPlayerUnit;

    public bool IsOccupied()
    {
        return m_OccupyingPlayerUnit != null;
    }

    public IPlayerUnit GetOccupyingUnit()
    {
        return m_OccupyingPlayerUnit;
    }

    public void SetOccupyingUnit(IPlayerUnit playerUnit)
    {
        m_OccupyingPlayerUnit = playerUnit;
    }
}
