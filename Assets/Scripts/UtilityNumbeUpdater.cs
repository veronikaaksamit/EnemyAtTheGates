using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class UtilityNumbeUpdater : MonoBehaviour
    {
        public Player MyPlayer;

        private Text[] texts;

        // Use this for initialization
        void Start ()
        {
            texts = GetComponentsInChildren<Text>(true);
        }
	
        // Update is called once per frame
        void FixedUpdate ()
        {
            UpdateTexts();
        }

        private void UpdateTexts()
        {
            for (int i = 0; i < texts.Length; i++)
            {
                switch (texts[i].tag)
                {
                    case "BarbedWire":
                        texts[i].text = MyPlayer.NumOfWires.ToString();
                        break;
                    case "Mine":
                        texts[i].text = MyPlayer.NumOfMines.ToString();
                        break;
                    case "TankBarrier":
                        texts[i].text = MyPlayer.NumOfTankBarriers.ToString();
                        break;
                    case "Barricade":
                        texts[i].text = MyPlayer.NumOfBarricades.ToString();
                        break;
                    case "ManPower":
                        texts[i].text = MyPlayer.GetManPowerValue().ToString();
                        break;
                    case "Munition":
                        texts[i].text = MyPlayer.GetTankMunitionValue().ToString();
                        break;
                    case "Weapons":
                        texts[i].text = MyPlayer.GetWeaponsValue().ToString();
                        break;
                    default:
                        Debug.Log(texts[i].tag + "is not between cases");
                        break;
                }
            }
        }
    }
}
