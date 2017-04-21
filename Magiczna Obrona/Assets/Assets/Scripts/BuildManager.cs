using UnityEngine;

public class BuildManager : MonoBehaviour {

	//skrypt odpowiedzialny za wybór rodzaju wieży do zbudowania

	// wzorzec projektowy singleton - zakładamy, że będzie tylko jedna instancja typu BuildManager i od razu ustalamy do niej referencję
	// niepraktyczne przy ilości BuildManagerów większej niż 1

	public static BuildManager instance;
	public GameObject buildEffect;

	private TowerBlueprint towerToBuild;

	void Awake () 
	{
		if (instance != null) 
		{
			Debug.LogError ("Another instance of BuildManager exists!");
		}
		instance = this;
	}

	public bool CanBuild { get { return towerToBuild != null; } } // właściwość zamiast funkcji sprawdzająca czy na polu już istnieje obiekt
	public bool HasMoney { get { return PlayerStats.Money >= towerToBuild.cost; } }

	// metoda odpowiadająca za budowanie wieżyczki
	public void BuildTowerOn (Field field) 
	{
		if (PlayerStats.Money < towerToBuild.cost) 
		{
			Debug.Log ("Not enough money!");
			return; 
		}

		PlayerStats.Money -= towerToBuild.cost;

		GameObject tower = (GameObject)Instantiate(towerToBuild.prefab, field.GetBuildPosition(), Quaternion.identity);
		field.tower = tower;

		GameObject effect = (GameObject)Instantiate(buildEffect, field.GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);

		Debug.Log ("Tower built! Money left: " + PlayerStats.Money);
	}

	public void SelectTowerToBuild (TowerBlueprint tower) 
	{
		towerToBuild = tower;
	}

}
