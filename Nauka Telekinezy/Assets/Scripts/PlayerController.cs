using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text obeliskText;
	public GameObject lastObelisk;
	public GameObject lastTrigger;

	private Rigidbody rb;
	private int count;


	void Start() 
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
	}

	void FixedUpdate() 
	{
		
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

	}

	void OnTriggerEnter (Collider other) 
	{
		if (other.CompareTag("Trigger")) 
		{
			count += 1;
			SetCountText();
		}
	}

	void SetCountText ()
	{
		obeliskText.text = "Aktywowano obelisków: " + count.ToString ();
		if (count >= 4) {
			lastObelisk.SetActive(true);
			lastTrigger.SetActive(true);
		}
	}
}
