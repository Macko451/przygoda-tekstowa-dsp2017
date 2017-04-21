using UnityEngine;

public class TowerShop : MonoBehaviour {

	public TowerBlueprint cannonTower;
	public TowerBlueprint mageTower;

	BuildManager buildManager;

	void Start() 
	{
		buildManager = BuildManager.instance;
	}

	public void SelectStandardTower () 
	{
		Debug.Log ("Standard Tower Selected");

		buildManager.SelectTowerToBuild(cannonTower);
	}

	public void SelectMageTower () 
	{
		Debug.Log ("Mage Tower Selected");
		buildManager.SelectTowerToBuild(mageTower);
	}

}
