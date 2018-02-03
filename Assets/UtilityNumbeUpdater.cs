using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

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
                case "Gold": break;
                default:
                    Debug.Log(texts[i].tag + "is not between cases");
                    break;
            }
        }
    }
}
