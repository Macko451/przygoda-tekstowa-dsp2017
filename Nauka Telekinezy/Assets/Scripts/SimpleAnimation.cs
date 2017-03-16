using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimpleAnimation : MonoBehaviour {

	public GameObject magicAnimation;

	void OnTriggerEnter (Collider other) 
	{
		if (other.CompareTag("Player")) 
		{
			magicAnimation.SetActive (true);
			gameObject.SetActive(false);
		}
	}
}
