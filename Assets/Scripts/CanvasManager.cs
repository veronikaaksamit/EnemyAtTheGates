using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{

    public Player Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
        Button[] buttons = this.GetComponentsInChildren<Button>(true);
	    //Debug.Log("Number of buttons is" + buttons.Length);

        for (int i = 0; i < buttons.Length; i++)
	    {
	        switch (buttons[i].tag)
	        {
                case "MachineGun":
                    break;
	            case "Sniper": break;
	            case "AntiAircraftW": break;
	            case "BarbedWire": break;
	            case "Mine": break;
	            case "TankBarrier": break;
	            case "Bomber": break;
	            default: Debug.Log(buttons[i].tag + "is not between cases");
                    break;
            }
	    }
	}
}
