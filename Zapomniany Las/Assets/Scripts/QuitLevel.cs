﻿using UnityEngine;
using System.Collections;

public class QuitLevel : MonoBehaviour {

	void OnTriggerEnter (Collider other) 
	{
		if (other.CompareTag("Player")) 
		{
			Application.Quit();
		}
	}
}
