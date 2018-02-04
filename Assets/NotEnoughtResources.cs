using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotEnoughtResources : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void SetNotEnoughForFewSeconds()
    {
        StartCoroutine(ActivateFor2Seconds());
        

    }

    public IEnumerator ActivateFor2Seconds()
    {
        GetComponent<Text>().text = "Not enough resources";
        yield return new WaitForSeconds(3);
        GetComponent<Text>().text = "";
    }
}
