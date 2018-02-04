using System;
using System.Linq;
using NUnit.Framework.Constraints;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public int NumOfMines;
        public int NumOfTankBarriers;
        public int NumOfWires;

        public GameObject InfantrymanPrefab;
        public GameObject SniperPrefab;
        public GameObject MachineGunNestPrefab;
        public GameObject AntiAircraftWarfarePrefab;

        public GameObject[] Costs;

        public int ManpowerIncomePerS = 1;
        private float m_lastManpowerIncomeTime = 0.0f;

        public GameResources[] Resources =
        {
            new GameResources(GameResourcesType.Manpower, 0),
            new GameResources(GameResourcesType.Weapons, 0),
            new GameResources(GameResourcesType.TankMunition, 0)
        };

        public IBlockade[] AvailableBlockades;

        void Start()
        {

        }

        void Update()
        {
            if (Mathf.Abs(Time.time - m_lastManpowerIncomeTime) >= 1.0f)
            {
                Resources[0].Count += ManpowerIncomePerS;
                m_lastManpowerIncomeTime = Time.time;
            }
        }

        public GameResources[] GetValueOfUtility(string tag)
        {
            GameResources[] values = new GameResources[3];
            foreach (var cost in Costs)
            {
                UtilityCost utilCost = cost.GetComponent<UtilityCost>();

                if (cost.tag.Equals(tag))
                {
                    values[0] = new GameResources(GameResourcesType.Manpower, utilCost.ManPowerCost);
                    values[1] = new GameResources(GameResourcesType.Weapons, utilCost.WeaponsCost);
                    values[2] = new GameResources(GameResourcesType.TankMunition, utilCost.MunitionCost);
                }
            }
            return values;
        }

        public int GetManPowerValue()
        {
            return Resources.Where(a => a.Type == GameResourcesType.Manpower)
                .Select(b => b.Count).FirstOrDefault();
        }

        public int GetWeaponsValue()
        {
            return Resources.Where(a => a.Type == GameResourcesType.Weapons)
                .Select(b => b.Count).FirstOrDefault();
        }

        public int GetTankMunitionValue()
        {
            return Resources.Where(a => a.Type == GameResourcesType.TankMunition)
                .Select(b => b.Count).FirstOrDefault();
        }

        public void UseMine()
        {
            --this.NumOfMines;
            //Debug.Log("Number of mines "+ NumOfMines);
        }

        public void UseTankBarrier()
        {
            --this.NumOfTankBarriers;
            //Debug.Log("Number of TankBarrier " + NumOfTankBarriers);
        }

        public void UseBarbedWire()
        {
            --this.NumOfWires;
            //Debug.Log("Number of BarbedWire " + NumOfWires);
        }

        public bool CanUseThatElement(String elementTag)
        {
            switch (elementTag)
            {
                case "BarbedWire":
                    return NumOfWires > 0;
                case "Mine":
                    return NumOfMines > 0;
                case "TankBarrier":
                    return NumOfTankBarriers > 0;
                case "Bomber": break;
                default:
                    Debug.Log(elementTag + "is not between cases");
                    break;
            }
            return false;
        }

        public void UseThatElement(String elementTag)
        {
            switch (elementTag)
            {
                case "BarbedWire":
                    UseBarbedWire();
                    break;
                case "Mine":
                    UseMine();
                    break;
                case "TankBarrier":
                    UseTankBarrier();
                    break;
                case "Bomber": break;
                default:
                    Debug.Log(elementTag + "is not between cases");
                    break;
            }

            //TODO: bombarder??
        }
    }
}
