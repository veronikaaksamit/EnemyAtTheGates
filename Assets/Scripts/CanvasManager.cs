using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class CanvasManager : MonoBehaviour
    {

        public Player Player;
        private Button[] buttons;

        // Use this for initialization
        void Start () {
		    buttons = this.GetComponentsInChildren<Button>();
        }
	
        public void UpdateButtons()
        {
             
            Debug.Log("Number of buttons is" + buttons.Length);

            for (int i = 0; i < buttons.Length; i++)
            {
                switch (buttons[i].tag)
                {
                    case "MachineGun":
                        break;
                    case "Sniper": break;
                    case "AntiAircraftW": break;
                    case "BarbedWire":
                        if (Player.NumOfWires <= 0)
                        {
                            buttons[i].enabled = false;
                        }
                        break;
                    case "Mine":
                        if (Player.NumOfMines <= 0)
                        {
                            buttons[i].enabled = false;
                        }
                        break;
                    case "TankBarrier":
                        if (Player.NumOfTankBarriers <= 0)
                        {
                            buttons[i].enabled = false;
                        }
                        break;
                    case "Bomber": break;
                    default: Debug.Log(buttons[i].tag + "is not between cases");
                        break;
                }
            }
        }
    }
}
