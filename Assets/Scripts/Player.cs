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
        public GameObject TankPrefab;

        public int ManpowerIncomePerS = 1;
        private float m_lastManpowerIncomeTime = 0.0f;

        public GameResources[] Resources = 
        {
            new GameResources(GameResourcesType.Manpower, 0),
            new GameResources(GameResourcesType.Weapons, 0),
            new GameResources(GameResourcesType.TankMunition, 0) 
        };

        public IBlockade[] AvailableBlockades;

        void Update()
        {
            if (Mathf.Abs(Time.time - m_lastManpowerIncomeTime) >= 1.0f)
            {
                Resources[0].Count += ManpowerIncomePerS;
                m_lastManpowerIncomeTime = Time.time;
            }
        }

        public void UseMine()
        {
            --this.NumOfMines;
            Debug.Log("Number of mines "+ NumOfMines);
        }

        public void UseTankBarrier()
        {
            --this.NumOfTankBarriers;
            Debug.Log("Number of TankBarrier " + NumOfTankBarriers);
        }

        public void UseBarbedWire()
        {
            --this.NumOfWires;
            Debug.Log("Number of BarbedWire " + NumOfWires);
        }

        //TODO: bombarder??
    }
}
