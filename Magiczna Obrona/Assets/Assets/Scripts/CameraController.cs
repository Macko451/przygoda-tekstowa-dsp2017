using UnityEngine;

public class CameraController : MonoBehaviour {

	public float panSpeed = 30f; // szybkość przesuwania ekranu
	public float panBorderThickness = 10f;

	public float scrollSpeed = 5f;
	public float minY = 10f;
	public float maxY = 80f;

	private bool enabledToMove = true;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
			enabledToMove = !enabledToMove;

		if (!enabledToMove)
			return;
		
		if (Input.GetKey ("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) {
			transform.Translate (Vector3.forward * panSpeed * Time.deltaTime, Space.World);
		}

		if (Input.GetKey ("s") || Input.mousePosition.y <= panBorderThickness) {
			transform.Translate (Vector3.back * panSpeed * Time.deltaTime, Space.World);
		}

		if (Input.GetKey ("a") || Input.mousePosition.x <= panBorderThickness) { // sprawdzamy pozycję myszy względem ekranu (wartości od 0.0 do 1.1)
			transform.Translate (Vector3.left * panSpeed * Time.deltaTime, Space.World);
		}

		if (Input.GetKey ("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) {
			transform.Translate (Vector3.right * panSpeed * Time.deltaTime, Space.World);
		}

		float scroll = Input.GetAxis ("Mouse ScrollWheel");

		Vector3 currentPos = transform.position;

		currentPos.y -= scroll * 500 * scrollSpeed * Time.deltaTime; // przybliżanie i oddalanie
		currentPos.y = Mathf.Clamp (currentPos.y, minY, maxY); // blokada ruchów oddalenia i przybliżenia

		transform.position = currentPos;
	}
}
