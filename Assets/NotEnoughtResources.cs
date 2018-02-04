using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotEnoughtResources : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void SetActiveForFewSeconds()
    {
        StartCoroutine(ActivateFor10Seconds());
        gameObject.SetActive(true);

    }

    public IEnumerator ActivateFor10Seconds()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(10);
        gameObject.SetActive(false);
    }
}
