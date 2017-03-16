using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour {

	void OnTriggerEnter (Collider other) 
	{
		if (other.CompareTag("Player")) 
		{
			SceneManager.LoadScene("Telekinesis");
		}
	}
}
