﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameLoading : MonoBehaviour {

	// Use this for initialization
	public void LoadNewGame ()
	{
        SceneManager.LoadScene("Level1");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
