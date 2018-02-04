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
        public int NumOfBarriers;

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

        public void UseBarrier()
        {
            --this.NumOfBarriers;
            //Debug.Log("Number of BarbedWire " + NumOfWires);
        }

        public void UseManPower(int value)
        {
            GameResources gr= Resources.FirstOrDefault(a => a.Type == GameResourcesType.Manpower);
            gr.Count = gr.Count - value;
        }

        public void UseWeapons(int value)
        {
            GameResources gr = Resources.FirstOrDefault(a => a.Type == GameResourcesType.Weapons);
            gr.Count = gr.Count - value;
        }

        public void UseTankMunition(int value)
        {
            GameResources gr = Resources.FirstOrDefault(a => a.Type == GameResourcesType.TankMunition);
            gr.Count = gr.Count - value;
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
                case "Barrier":
                    return NumOfBarriers > 0;
                case "Bomber":
                case "Sniper":
                case "MachineGun":
                case "AntiAircraftW":
                case "Soldier":
                    return CheckIfCanPayFor(elementTag);
                default:
                    Debug.Log(elementTag + "is not between cases in Player CanUseThatElement method");
                    break;
            }
            return false;
        }

        private bool CheckIfCanPayFor(String elemTag)
        {
            GameResources[] res =  GetValueOfUtility(elemTag);
            int v1 = 0;
            int v2 = 0;
            int v3 = 0;
            for (int i = 0; i < res.Length; i++)
            {
                if (res[i].Type == GameResourcesType.Manpower)
                {
                    v1 = res[i].Count;
                }
                if (res[i].Type == GameResourcesType.Weapons)
                {
                    v2 = res[i].Count;
                }
                if (res[i].Type == GameResourcesType.TankMunition)
                {
                    v3 = res[i].Count;
                }
            }
            return CanPayValue(v1, v2, v3);
        }

        private bool CanPayValue(int manPower, int weapons, int munition)
        {
            if (GetManPowerValue() >= manPower)
            {
                if (GetWeaponsValue() >= weapons)
                {
                    if (GetTankMunitionValue() >= munition)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void PayForUtility(String elemTag)
        {
            GameResources[] res = GetValueOfUtility(elemTag);
            int v1 = 0;
            int v2 = 0;
            int v3 = 0;
            for (int i = 0; i < res.Length; i++)
            {
                if (res[i].Type == GameResourcesType.Manpower)
                {
                    v1 = res[i].Count;
                }
                if (res[i].Type == GameResourcesType.Weapons)
                {
                    v2 = res[i].Count;
                }
                if (res[i].Type == GameResourcesType.TankMunition)
                {
                    v3 = res[i].Count;
                }
            }
            PayTheValue(v1, v2, v3);
        }

        private void PayTheValue(int manPower, int weapons, int munition)
        {
            UseManPower(manPower);
            UseWeapons(weapons);
            UseTankMunition(munition);
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
                case "Barrier":
                    UseBarrier();
                    break;
                case "Bomber":
                case "Sniper":
                case "MachineGun":
                case "AntiAircraftW":
                case "Soldier":
                    PayForUtility(elementTag);
                    break;
                default:
                    Debug.Log(elementTag + "is not between cases in Player UseThatElement method");
                    break;
                    
            }

            //TODO: bombarder??
        }
    }
}
