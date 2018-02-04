using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeButtonDescription : MonoBehaviour
{
	
    public void AddText(String text)
    {
        this.GetComponent<Text>().text = text;
        Debug.Log("hovering");
    }

    public void RemoveText()
    {
        this.GetComponent<Text>().text = "";
    }

}
