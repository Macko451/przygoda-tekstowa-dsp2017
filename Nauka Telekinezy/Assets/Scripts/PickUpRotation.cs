using UnityEngine;
using System.Collections;

public class PickUpRotation : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0.0f, 30, 0.0f) * Time.deltaTime);
	}
}
