using UnityEngine;
using UnityEngine.EventSystems;

public class Field : MonoBehaviour {

	BuildManager buildManager;

	public Color hoverColor;
	public Color needMoreMoneyToBuildColor;
	public Vector3 positionOffset; // wysunięcie obiektu do góry, aby nie tonął w podłożu

	[Header("Optional")] // możemy na dowolnych polach dodać wieżę przed rozpoczęciem gry, aby pomóc graczowi
	public GameObject tower;

	private Renderer rend;
	private Color startColor;

	void Start () 
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color; // wyjściowy kolor pola, na wypadek gdybyśmy chcieli mieć inny kolor niż biały
		buildManager = BuildManager.instance;
	}

	// uproszczone ustalenie pozycji budowy
	public Vector3 GetBuildPosition () 
	{
		return transform.position + positionOffset;
	}

	void OnMouseDown () 
	{
		if (EventSystem.current.IsPointerOverGameObject()) // upewnienie się czy kursor nie znajduje się nad innym obiektem gry
			return;

		if (!buildManager.CanBuild)
			return;

		if (tower != null) 
		{
			Debug.Log ("Can't build a tower here! - TODO: Display some kind of a message to the user.");
			return;
		}

		// uproszczenie kodu poprzez przeniesienie funkcji budowania do BuildManagera
		buildManager.BuildTowerOn(this);
	}

	// zmiana koloru materiału obiektu Field po najechaniu na niego myszą
	void OnMouseEnter() 
	{
		if (EventSystem.current.IsPointerOverGameObject()) // nie podświetla pola jak najedziemy na panel lub inny element UI
			return;

		if (!buildManager.CanBuild)
			return;

		if (buildManager.HasMoney) 
		{
			rend.material.color = hoverColor;
		} else {
			rend.material.color = needMoreMoneyToBuildColor;
		}


	}

	void OnMouseExit () 
	{
		rend.material.color = startColor;
	}
	
}
