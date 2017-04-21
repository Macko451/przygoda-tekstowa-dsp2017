using UnityEngine;
using System.Collections;

public class SoundActivator : MonoBehaviour {

	public float delayScream;
	
	private AudioSource myAudio;


	void Start () 
	{
		myAudio = GetComponent<AudioSource>();
		myAudio.PlayDelayed(delayScream);
	}
}
